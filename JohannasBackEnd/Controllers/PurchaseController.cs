using JohannasBackEnd.Domain.DTOs;
using JohannasBackEnd.Domain.Models;
using JohannasBackEnd.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Web;

namespace JohannasBackEnd.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "*")]
    public class PurchaseController : ApiController
    {
     

        // GET: api/Purchase
        [Route("api/Purchase/GetPurchaseList")]
        [HttpPost]
        public IEnumerable<PurchaseDTO> Get([FromBody] string userName)
        {
           return PurchaseManager.GetInstance().GetAllPurchases(userName);
        }

        // GET: api/Purchase
        [Route("api/Purchase/GetPurchaseListByDate")]
        [HttpPost]
        public IEnumerable<PurchaseDTO> Get([FromBody] PurchaseDateRequestDTO rq)
        {
            return PurchaseManager.GetInstance().GetAllPurchases(rq);
        }

        // GET: api/Purchase/5
        public Purchase Get(int id)
        {
            var purchase = PurchaseManager.GetInstance().GetPurchaseById(id);
            return purchase;
        }

        // POST: api/Purchase
        public void Post([FromBody]CreatePurchaseDTO purchase)
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
