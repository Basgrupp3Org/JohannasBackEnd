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
    }
}