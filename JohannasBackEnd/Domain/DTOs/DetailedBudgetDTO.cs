using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.DTOs
{
    public class DetailedBudgetDTO
    {
        public int Id { get; set; }
        public string BudgetName { get; set; }
        public decimal BudgetSum { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public string User { get; set; }
        public decimal MaxSpent { get; set; }
        public decimal CurrentSpent { get; set; }
        public string CategoryName { get; set; }
    }
}