using JohannasBackEnd.Domain;
using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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


            string users = category.User.ToString();
            using (var db = new MyDBContext())
            {
                var person = db.Users.Where(u => u.UserName == users).FirstOrDefault();
                category.User = person;
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(string name)
        {
            using (var db = new MyDBContext())
            {
                if(db.Categories.Find(name) != null)
                {
                    db.Categories.Remove(db.Categories.Find(name));
                    db.SaveChanges();
                }
            }
        }

        public Category GetCategoryByName(string name)
        {
            using (var db = new MyDBContext())
            {
                var category = db.Categories.Find(name);
                return category;
            }
        }
    }
}