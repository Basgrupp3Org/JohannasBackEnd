﻿using JohannasBackEnd.Domain.Models;
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

    public class UserController : ApiController
    {
        // GET: api/User

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/User
        // en metod för att registera en användare
        public string Post([FromBody] User user)
        {
            bool myBool;
            myBool = UserManager.GetInstance().CreateUser(user);
            if (myBool == true)
            {
                return "successful";
            }
            else
            {
                return "unsuccessful";
            }


        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
