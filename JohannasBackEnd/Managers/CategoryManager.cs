using JohannasBackEnd.Domain;
using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using JohannasBackEnd.Domain.DTOs;

namespace JohannasBackEnd.Managers
{
    public class CategoryManager
    {
        private static CategoryManager _instance;

        public static CategoryManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CategoryManager();
            }
            return _instance;
        }
        private CategoryManager()
        {

        }

        public void CreateCategory(Category category)
        {
            string users = category.User.UserName;
            //string budgetName = category.Budget.BudgetName;

            using (var db = new MyDBContext())
            {
                var person = db.Users.Where(u => u.UserName == users).FirstOrDefault();
                //var budget = db.Budgets.Where(x => x.BudgetName == budgetName).FirstOrDefault();
                category.User = person;
                //category.Budget = budget;
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            using (var db = new MyDBContext())
            {
                if(db.Categories.Find(id) != null)
                {
                    db.Categories.Remove(db.Categories.Find(id));
                    db.SaveChanges();
                }
            }
        }

        public Category GetCategoryById(int id)
        {
            using (var db = new MyDBContext())
            {
                var category = db.Categories.Find(id);
                return category;
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var db = new MyDBContext())
            {
                var existingCategory = db.Categories.Where(c => c.Id == category.Id).FirstOrDefault();

                if (existingCategory != null)
                {
                    existingCategory.MaxSpent = category.MaxSpent;
                    existingCategory.CurrentSpent = category.CurrentSpent;
                    existingCategory.Name = category.Name;

                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<CategoryDTO> GetCategoryList(string userName)
        {
            using (var db = new MyDBContext())
            {
                var returnList = new List<CategoryDTO>();
                var categories = db.Categories.Where(c => c.User.UserName == userName).ToList();

                foreach (var item in categories)
                {
                    returnList.Add(
                    new CategoryDTO
                    {
                        MaxSpent = item.MaxSpent,
                        CurrentSpent = item.CurrentSpent,
                        Name = item.Name,
                        User = item.User.UserName,
                    });
                }

                return returnList;
            }
        }
    }
}