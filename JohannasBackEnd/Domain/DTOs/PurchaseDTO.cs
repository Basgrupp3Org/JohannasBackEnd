using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.DTOs
{
    public class PurchaseDTO
    {
        public decimal Price { get; set; }
        public string PurchaseName { get; set; }
        public string Date { get; set; }
        //public string Store { get; set; }
        public string Category { get; set; }
        public string User { get; set; }
    }
}