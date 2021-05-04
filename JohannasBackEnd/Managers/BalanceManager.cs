using JohannasBackEnd.Domain;
using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Managers
{
    public class BalanceManager
    {
        private static BalanceManager _instance;
       

        public static BalanceManager GetInstance()
        {
            
            if (_instance == null)
            {
                _instance = new BalanceManager();
            }
            return _instance;
        }
        private BalanceManager()
        {
            
        }

        public void CreateBalance(Balance balance)
        {
            string users = balance.User.UserName;

            using (var db = new MyDBContext())
            {
                var person = db.Users.Where(u => u.UserName == users).FirstOrDefault();
                balance.User = person;
                db.Balances.Add(balance);
                person.BalanceUser += balance.Sum;
                db.SaveChanges();
            }
        }

        public void DeleteBalance(int id)
        {
            using (var db = new MyDBContext())
            {
                if (db.Balances.Find(id) != null)
                {
                    db.Balances.Remove(db.Balances.Find(id));
                    db.SaveChanges();
                }
            }
        }


        public decimal GetBalanceByUser(string UserName)
        {
            
            using (var db = new MyDBContext())
            {
                var user = db.Users.Where(x => x.UserName == UserName).FirstOrDefault();

                return user.BalanceUser;
            }
        }

        //public decimal GetBalanceByUser(string UserName)
        //{

        //    using (var db = new MyDBContext())
        //    {
        //        var balances = db.Balances
        //            .Where(b => b.User.UserName == UserName).AsEnumerable();
        //        var user = db.Users.Where(x => x.UserName == UserName).FirstOrDefault();




        //        var result = 0m;

        //        foreach (var item in balances)
        //        {
        //            result += item.Sum;
        //        }

        //        user.BalanceUser = result;
        //        db.SaveChanges();


        //        return user.BalanceUser;
        //    }
        //}


        // UseLEsS??
        public void SetBalanceForUser (string userName, decimal price)
        {
            using(var db = new MyDBContext())
            {
                var user = db.Users.Where(x => x.UserName == userName).FirstOrDefault();

                user.BalanceUser -= price;
                db.SaveChanges();
            }
        }



      
    }
}