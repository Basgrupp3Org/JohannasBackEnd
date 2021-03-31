using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.DTOs
{
    public class PurchaseCategoryRequestDTO
    {
        public User User { get; set; }

        public Category Category { get; set; }
    }
}