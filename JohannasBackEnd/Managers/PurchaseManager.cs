
﻿using JohannasBackEnd.Domain;
using JohannasBackEnd.Domain.Models;
using JohannasBackEnd.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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
        public IEnumerable<PurchaseDTO> GetAllPurchases(string userName)
        {
            
            using (var db = new MyDBContext())
            {
                var returnList = new List<PurchaseDTO>();
                var purchases = db.Purchases.Where(x => x.User.UserName == userName).ToList();

                foreach(var item in purchases)
                {
                    returnList.Add(
                    new PurchaseDTO
                    {
                        Price = item.Price,
                        PurchaseName = item.PurchaseName,
                        Date = item.Date,
                        User = item.User.UserName
                    });

                }

                return returnList;




            }
           
        }
    }

}