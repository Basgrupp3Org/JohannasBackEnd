using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.DTOs
{
    public class PurchaseDateRequestDTO
    {

        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        //public virtual Store Store { get; set; }
        //public virtual Category Category { get; set; }
        public User User { get; set; }
    }
}