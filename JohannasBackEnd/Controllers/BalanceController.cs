﻿using JohannasBackEnd.Domain.Models;
using JohannasBackEnd.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JohannasBackEnd.Controllers
{
    public class BalanceController : ApiController
    {
        // GET: api/Balance
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Balance/5
        public Balance Get(int id)
        {
            var balance = BalanceManager.GetInstance().GetBalanceById(id);
            return balance;
        }

        // POST: api/Balance
        public void Post([FromBody]Balance balance)
        {
            BalanceManager.GetInstance().CreateBalance(balance);
        }

        // PUT: api/Balance/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Balance/5
        public void Delete(int id)
        {
            BalanceManager.GetInstance().DeleteBalance(id);
        }
    }
}
