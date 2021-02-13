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
        public void CreateCategory(Category category)
        {
            using (var db = new MyDBContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(string Name)
        {
            using (var db = new MyDBContext())
            {
                if(db.Categories.Find(Name) != null)
                {
                    db.Categories.Remove(db.Categories.Find(Name));
                    db.SaveChanges();
                }
            }
        }

        public Category GetCategoryByName(string Name)
        {
            using (var db = new MyDBContext())
            {
                var category = db.Categories.Find(Name);
                return category;
            }
        }
    }
}