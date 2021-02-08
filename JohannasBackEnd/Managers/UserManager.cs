using JohannasBackEnd.Domain;
using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Managers
{
    public class UserManager
    {
        private static UserManager _instance;

        public static UserManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserManager();
            }
            return _instance;
        }
        private UserManager()
        {

        }

        public bool CreateUser(User user)
        {
            using (var db = new MyDBContext())
            {
                var person = db.Users.Where(p => p.UserName == user.UserName).FirstOrDefault();
                if (person == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool GetUser(User user)
        {
            using (var db = new MyDBContext())
            {
              
                if (user != null)
                {
                    var person = db.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
                    if(person != null)
                    {
                        return true;
                    }
                    else { return false; }
                   
                }
                else
                {
                    return false;
                }
            }
        }

        //    public User GetUserByUserName(string userName)
        //    {
        //        using (var db = new MyDBContext())
        //        {
        //            var user = db.Users.Where(p => p.UserName == userName);
        //            var person = db.Users.Find(userName);
        //            return person;
        //        }
        //    }

        //    public User GetUserByID(int id)
        //    {
        //        using (var db = new MyDBContext())
        //        {
        //            var user = db.Users.Find(id);
        //            return user;
        //        }
        //    }



        //    public void DeleteUserByID(int id)
        //    {
        //        using (var db = new MyDBContext())
        //        {
        //            var user = db.Users.Find(id);
        //            db.Users.Remove(user);

        //            db.SaveChanges();
        //        }
        //    }

        //    public void DeleteUserByName(string name)
        //    {
        //        using (var db = new MyDBContext())
        //        {
        //            var user = db.Users.Where(p => p.UserName == name).FirstOrDefault();
        //            if (user != null)
        //            {
        //                db.Users.Remove(user);
        //            }
        //            db.SaveChanges();
        //        }
        //    }

        //    public void DeleteUser(User user)
        //    {
        //        using (var db = new MyDBContext())
        //        {
        //            db.Users.Remove(user);

        //            db.SaveChanges();
        //        }
        //    }

        //    public void UpdatePassword(User user, string password)
        //    {
        //        using (var db = new MyDBContext())
        //        {
        //            var person = db.Users.Where(p => p.Id == user.Id).FirstOrDefault();
        //            if (person != null)
        //            {
        //                person.Password = password;
        //                db.SaveChanges();
        //            }
        //        }
        //    }

        //    public void UpdatePassword(string userName, string password)
        //    {
        //        using (var db = new MyDBContext())
        //        {
        //            var person = db.Users.Where(p => p.UserName == userName).FirstOrDefault();
        //            if (person != null)
        //            {
        //                person.UserName = password;
        //            }

        //            db.SaveChanges();
        //        }
        //    }
        //
    }
}