using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.DTOs
{
    public class SetCategoryOnBudgetDTO
    {
        public Category Category { get; set; }
        public Budget Budget { get; set; }
        public User User { get; set; }
    }
}