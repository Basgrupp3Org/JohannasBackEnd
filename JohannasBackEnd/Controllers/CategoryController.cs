using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using JohannasBackEnd.Domain.DTOs;
using JohannasBackEnd.Domain.Models;
using JohannasBackEnd.Managers;

namespace JohannasBackEnd.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {

        [Route("api/Category/GetCategoryForPurchase")]
        [HttpPost]
        public IEnumerable<CategoryDTO> Get([FromBody] CreatePurchaseDTO dto)
        {
            return CategoryManager.GetInstance().GetCategoryList(dto);
        }

        // GET: api/Category
        [Route("api/Category/GetCategoryList")]
        [HttpPost]
        public IEnumerable<CategoryDTO> Get([FromBody] string userName)
        {
            return CategoryManager.GetInstance().GetCategoryList(userName);
        }

        // GET: api/Category/5
        public CategoryDTO Get(int id)
        {
            var category = CategoryManager.GetInstance().GetCategoryById(id);
            return category;
        }

        // POST: api/Category
        [Route("api/Category/")]
        [HttpPost]
        public void Post([FromBody]Category category)
        {


            CategoryManager.GetInstance().CreateCategory(category);

        }

        // PUT: api/Category/5
        [HttpPut]
        [Route("api/EditCategory/")]
        public void Put([FromBody] EditCategoryDTO category)
        {
            CategoryManager.GetInstance().UpdateCategory(category);
        }

        // DELETE: api/Category/5
        [Route("api/Category/Delete")]
        [HttpPost]
        public void Delete([FromBody] DeleteCategoryRequestDTO rq)
        {
            CategoryManager.GetInstance().DeleteCategory(rq);
        }
    }
}
