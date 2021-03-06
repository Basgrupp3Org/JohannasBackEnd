﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.Models
{
    public class Category : Entity
    {
        public decimal MaxSpent { get; set; }
        public decimal CurrentSpent { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Budget> Budget { get; set; }
        public virtual User User { get; set; }
    }
}