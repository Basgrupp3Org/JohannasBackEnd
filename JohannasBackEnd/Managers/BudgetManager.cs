using JohannasBackEnd.Domain.DTOs;
using JohannasBackEnd.Domain;
using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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
            string users = budget.User.UserName;

            using (var db = new MyDBContext())
            {
                var person = db.Users.Where(u => u.UserName == users).FirstOrDefault();
                budget.User = person;
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

        public IEnumerable<BudgetDTO> GetBudgetList(string UserName)
        {
            using (var db = new MyDBContext())
            {
                var returnList = new List<BudgetDTO>();
                var budgets = db.Budgets.Where(x => x.User.UserName == UserName).ToList();
               
               
                foreach (var item in budgets)
                {
                    returnList.Add(
                    new BudgetDTO
                    {
                        Id = item.Id,
                        BudgetName = item.BudgetName,
                        BudgetSum = item.BudgetSum,
                        StartDate = item.StartDate.ToString("yyyy-MM-dd"),
                        EndDate = item.EndDate.ToString("yyyy-MM-dd"),
                        User = item.User.UserName,


                        //Categories = item.Categories

                    });

                }

                return returnList;
            }
        }

        public void SetCategoryForBudget(SetCategoryOnBudgetDTO dto)
        {
            using (var db = new MyDBContext())
            {
                var budgets = db.Budgets.Where(x => x.Id == dto.Budget.Id && x.User.UserName == dto.User.UserName).FirstOrDefault();
                var category = db.Categories.Where(x => x.Id == dto.Category.Id && x.User.UserName == dto.User.UserName).FirstOrDefault();
                budgets.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public IEnumerable<DetailedBudgetDTO> GetDetailedBudgetList(string UserName)
        {
            using (var db = new MyDBContext())
            {
                var returnList = new List<DetailedBudgetDTO>();
               
                var budgets = db.Budgets
                    .Where(x => x.User.UserName.ToLower() == UserName.ToLower() && x.Categories.Any())
                    .Include("Categories").ToList();

                foreach (var item in budgets)
                {
                    var categoryDTOs = new List<CategoryDTO>();
                    foreach (var category in item.Categories)
                    {
                        categoryDTOs.Add(
                            new CategoryDTO
                            {
                                Name = category.Name,
                                MaxSpent = category.MaxSpent,
                                CurrentSpent = category.CurrentSpent,
                            });
                    }
                    returnList.Add(
                    new DetailedBudgetDTO
                    {
                        Id = item.Id,
                        BudgetName = item.BudgetName,
                        BudgetSum = item.BudgetSum,
                        StartDate = item.StartDate.ToString("yyyy-MM-dd"),
                        EndDate = item.EndDate.ToString("yyyy-MM-dd"),
                        Categories = categoryDTOs,
                    }) ;
                    
                }

                return returnList;
            }
        }
    }
}