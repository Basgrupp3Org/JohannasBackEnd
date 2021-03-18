using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.DTOs
{
    public class CategoryDTO
    {
        public decimal MaxSpent { get; set; }
        public decimal CurrentSpent { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual Budget Budget { get; set; }
        public string User { get; set; }
    }
}