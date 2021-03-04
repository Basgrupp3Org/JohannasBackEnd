using JohannasBackEnd.Domain.Models;
using JohannasBackEnd.Domain.DTOs;
using JohannasBackEnd.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JohannasBackEnd.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BudgetController : ApiController
    {
        // GET: api/Budget
        [Route("api/Budget/GetBudgetList")]
        [HttpPost]
        public IEnumerable<BudgetDTO> Get([FromBody] string UserName)
        {
            return BudgetManager.GetInstance().GetBudgetList(UserName);
        }

        // GET: api/Budget/5
        public Budget Get(int id)
        {
            var budget = BudgetManager.GetInstance().GetBudgetById(id);
            return budget;
        }
        
        // POST: api/Budget
        [Route("api/Budget/CreateBudget")]
        [HttpPost]
        public void Post([FromBody] Budget budget)
        {
           BudgetManager.GetInstance().CreateBudget(budget);
        }

        // PUT: api/Budget/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Budget/5
        public void Delete(int id)
        {
            BudgetManager.GetInstance().DeleteBudget(id);
        }
    }
}
