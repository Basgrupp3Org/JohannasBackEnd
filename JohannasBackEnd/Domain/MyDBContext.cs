using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("name=ConnectionString")
        {


        }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}