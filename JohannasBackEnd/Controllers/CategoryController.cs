using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using JohannasBackEnd.Domain.Models;
using JohannasBackEnd.Managers;

namespace JohannasBackEnd.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        // GET: api/Category
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Category/5
        public Category Get(string name)
        {
          var category = CategoryManager.GetInstance().GetCategoryByName(name);
            return category;
        }

        // POST: api/Category
        [Route("api/Category/CreateCategory")]
        [HttpPost]
        public void Post([FromBody]Category category)
        {
            var newCat = category;

            newCat.Name = category.

            CategoryManager.GetInstance().CreateCategory(category);
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(string name)
        {
            CategoryManager.GetInstance().DeleteCategory(name);
        }
    }
}
