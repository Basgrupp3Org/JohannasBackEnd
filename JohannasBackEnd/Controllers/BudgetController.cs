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
using System.Threading.Tasks;

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

        [AcceptVerbs("GET", "POST")]
        [Route("api/Budget/GetDetailedBudgetList")]
      
        public IEnumerable<DetailedBudgetDTO> GetDetailedBudgetList([FromBody] int id)
        {
            return BudgetManager.GetInstance().GetDetailedBudgetList(id);
        }

        // GET: api/Budget/5
        public IEnumerable<DetailedBudgetDTO> Get(int id)
        {
            var budget = BudgetManager.GetInstance().GetDetailedBudgetList(id);
            return budget;
        }
        
        // POST: api/Budget
        [Route("api/Budget/CreateBudget")]
        [HttpPost]
        public void Post([FromBody] Budget budget)
        {
           BudgetManager.GetInstance().CreateBudget(budget);
        }
        [Route("api/Budget/SetCategoryForBudget")]
        [HttpPost]
        public bool SetCategoryForBudget([FromBody] SetCategoryOnBudgetDTO x)
        {
           bool z = BudgetManager.GetInstance().SetCategoryForBudget(x);

            return z;


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
