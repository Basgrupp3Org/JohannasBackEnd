using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.Models
{
    public class Balance : Entity
    {
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
        public string BalanceLabel { get; set; }
        [Required]
        public virtual User User { get; set; }

    }
}