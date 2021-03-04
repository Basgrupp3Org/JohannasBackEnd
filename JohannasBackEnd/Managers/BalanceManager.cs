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
                var balances = db.Balances
                    .Where(b => b.User.UserName == UserName).AsEnumerable();

                var result = 0m;

                foreach (var item in balances)
                {
                    result += item.Sum;
                }
                
                return result;
            }
        }

      
    }
}