using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.Models
{
    public class User : Entity
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Balance> Balance { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
    }
}