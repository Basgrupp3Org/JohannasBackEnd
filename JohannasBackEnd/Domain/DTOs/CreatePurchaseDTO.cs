using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.DTOs
{
    public class CreatePurchaseDTO
    {
        public decimal Price { get; set; }
        public string PurchaseName { get; set; }
        public string Date { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public Budget Budget { get; set; }

    }
}