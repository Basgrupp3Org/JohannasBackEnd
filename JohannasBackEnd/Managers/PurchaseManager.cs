
﻿using JohannasBackEnd.Domain;
using JohannasBackEnd.Domain.Models;
using JohannasBackEnd.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JohannasBackEnd.Managers
{
    public class PurchaseManager
    {
        private static PurchaseManager _instance;


        public static PurchaseManager GetInstance()
        {

            if (_instance == null)
            {
                _instance = new PurchaseManager();
            }
            return _instance;
        }
        private PurchaseManager()
        {

        }

        public void CreatePurchase(Purchase purchase)
        {
            string users = purchase.User.UserName;

            using (var db = new MyDBContext())
            {
                var person = db.Users.Where(u => u.UserName == users).FirstOrDefault();
                purchase.User = person;
                db.Purchases.Add(purchase);
                db.SaveChanges();
            }
        }

        public void CreatePurchase(CreatePurchaseDTO purchase)
        {
            string users = purchase.User.UserName;

            using (var db = new MyDBContext())
            {
                var person = db.Users.Where(u => u.UserName == users).FirstOrDefault();
                var category = db.Categories.Where(x => x.Id == purchase.Category.Id).FirstOrDefault();
                category.CurrentSpent += purchase.Price;
                var dateTime = DateTime.Parse(purchase.Date);
                var dto = new Purchase
                {
                    Price = purchase.Price,
                    PurchaseName = purchase.PurchaseName,
                    Date = dateTime,
                    Category = category,
                    User = person,
                };
                db.Purchases.Add(dto);
                db.SaveChanges();
            }
        }

        public void DeletePurchase(int id)
        {
            using (var db = new MyDBContext())
            {
                if (db.Purchases.Find(id) != null)
                {
                    db.Purchases.Remove(db.Purchases.Find(id));
                    db.SaveChanges();
                }
            }
        }

        public Purchase GetPurchaseById(int id)
        {
            using (var db = new MyDBContext())
            {
                var purchase = db.Purchases.Find(id);
                return purchase;
            }
        }
        public IEnumerable<PurchaseDTO> GetAllPurchases(UserDTO rq)
        {

            using (var db = new MyDBContext())
            {
                var user = db.Users.Where(x => x.UserName == rq.UserName).FirstOrDefault();
                var returnList = new List<PurchaseDTO>();
                var purchases = db.Purchases.Where(x => x.User.Id == user.Id)
                    .Include("Category")
                    .ToList();

                foreach (var item in purchases)
                {
                    returnList.Add(
                    new PurchaseDTO
                    {
                        Price = item.Price,
                        PurchaseName = item.PurchaseName,
                        Date = item.Date.ToString("yyyy-MM-dd"),
                        User = item.User.UserName,
                        Category = item.Category.Name

                    });

                }

                return returnList;


                //{

                //    //var purchases = db.Purchases.Where(p => p.Category.Where().ToList();

                //    var purchases = db.Purchases.Where(c => c.Category.Id == rq.Category.Id)
                //        .Include("Category")
                //        .ToList();

                //    foreach (var item in purchases)
                //    {
                //        returnList.Add(
                //        new PurchaseDTO
                //        {
                //            Price = item.Price,
                //            PurchaseName = item.PurchaseName,
                //            Category = item.Category.Name,
                //            Date = item.Date.ToString("yyyy-MM-dd"),
                //            User = item.User.UserName
                //        });

                //    }




            }
               
        }

        public IEnumerable<PurchaseDTO> GetAllPurchases(PurchaseDateRequestDTO rq)
        {

            using (var db = new MyDBContext())
            {
                var returnList = new List<PurchaseDTO>();
                var purchases = db.Purchases.Where(x => x.User.UserName == rq.User.UserName && x.Date > rq.FromDate && x.Date < rq.ToDate).ToList();

                foreach(var item in purchases)
                {
                            returnList.Add(
                            new PurchaseDTO
                            {
                                Price = item.Price,
                                PurchaseName = item.PurchaseName,
                                Category = item.Category.Name,
                                Date = item.Date.ToString("yyyy-MM-dd"),
                                User = item.User.UserName
                            });   
                   
                }

                

                return returnList;

            }

        }

        public IEnumerable<PurchaseDTO> GetAllPurchases(PurchaseCategoryRequestDTO rq)
        {

            using (var db = new MyDBContext())
            {
                var returnList = new List<PurchaseDTO>();
                //var purchases = db.Purchases.Where(p => p.Category.Where().ToList();

                var purchases = db.Purchases.Where(c => c.Category.Id == rq.Category.Id)
                    .Include("Category")
                    .ToList();

                foreach (var item in purchases)
                {
                    returnList.Add(
                    new PurchaseDTO
                    {
                        Price = item.Price,
                        PurchaseName = item.PurchaseName,
                        Category = item.Category.Name,
                        Date = item.Date.ToString("yyyy-MM-dd"),
                        User = item.User.UserName
                    });

                }



                return returnList;

            }

        }
    }

}