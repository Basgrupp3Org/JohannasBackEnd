using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace JohannasBackEnd.Domain.Models
{
    public class Store : Entity
    {
        public string Name { get; set; }
        [Required]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}