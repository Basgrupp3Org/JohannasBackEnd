using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.Models
{
    public class Budget : Entity
    {
        public string BudgetName { get; set; }
        public decimal BudgetSum { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual User User { get; set; }
    }
}