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
    public class PurchaseController : ApiController
    {
        // GET: api/Purchase
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Purchase/5
        public Purchase Get(int id)
        {
            var purchase = PurchaseManager.GetInstance().GetPurchaseById(id);
            return purchase;
        }

        // POST: api/Purchase
        public void Post([FromBody]Purchase purchase)
        {
            PurchaseManager.GetInstance().CreatePurchase(purchase);
        }

        // PUT: api/Purchase/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Purchase/5
        public void Delete(int id)
        {
            PurchaseManager.GetInstance().DeletePurchase(id);
        }
    }
}
