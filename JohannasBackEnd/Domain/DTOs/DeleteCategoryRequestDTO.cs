using JohannasBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannasBackEnd.Domain.DTOs
{
    public class DeleteCategoryRequestDTO
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}