using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.Models
{
    public class Purchase : Entity
    {
        public decimal Price { get; set; }
        public string PurchaseName { get; set; }
        public DateTime Date { get; set; }
        public virtual Store Store { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}