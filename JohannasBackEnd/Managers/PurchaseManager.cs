using JohannasBackEnd.Domain;
using JohannasBackEnd.Domain.Models;
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
            using (var db = new MyDBContext())
            {
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
        public IEnumerable<Purchase> GetAllPurchases(string userName)
        {
            var listOfPurchases = new List<Purchase>();
            using (var db = new MyDBContext())
            {
                listOfPurchases = db.Purchases.Where(p => p.User.UserName == userName).ToList();
            }
            return listOfPurchases;
        }
    }
}