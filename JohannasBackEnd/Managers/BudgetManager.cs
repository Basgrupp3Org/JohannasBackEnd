using JohannasBackEnd.Domain;
using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Managers
{
    public class BudgetManager
    {
        private static BudgetManager _instance;

        public static BudgetManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BudgetManager();
            }
            return _instance;
        }
        private BudgetManager()
        {

        }

        public void CreateBudget(Budget budget)
        {
            using (var db = new MyDBContext())
            {
                db.Budgets.Add(budget);
                db.SaveChanges();
            }
        }

        public void DeleteBudget(int id)
        {
            using (var db = new MyDBContext())
            {
                if (db.Budgets.Find(id) != null)
                {
                    db.Budgets.Remove(db.Budgets.Find(id));
                    db.SaveChanges();
                }
            }
        }

        public Budget GetBudgetById(int id)
        {
            using (var db = new MyDBContext())
            {
                var budget = db.Budgets.Find(id);
                return budget;
            }
        }

        public IEnumerable<Budget> GetBudgetList(string user)
        {
            using (var db = new MyDBContext())
            {
                var person = db.Users.Where(u => u.UserName == user).FirstOrDefault();
                var budgets = db.Budgets.Where(b => b.User == person).ToList();
                return budgets;
            }
        }
    }
}