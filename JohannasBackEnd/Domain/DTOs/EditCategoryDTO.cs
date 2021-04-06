using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.DTOs
{
    public class EditCategoryDTO
    {
        public int Id { get; set; }
        public decimal MaxSpent { get; set; }
        public string Name { get; set; }
    }
}