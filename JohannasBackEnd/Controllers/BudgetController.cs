using JohannasBackEnd.Domain.Models;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Budget/5
        public Budget Get(int id)
        {
            var budget = BudgetManager.GetInstance().GetBudgetById(id);
            return budget;
        }

        // POST: api/Budget
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
