using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDemo.Models;
using WebApiDemo.Models.Interface;
using WebApiDemo.Models.Repository;

namespace WebApiDemo.Controllers
{
    public class ProductsController : ApiController
    {
        private IRepository<Product> ProudctRepository;
        public ProductsController()
        {
            this.ProudctRepository = new ProductRepository();
        }

        // GET: api/Products
        public IQueryable<Product> GetProduct()
        {
            return ProudctRepository.GetAll();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = ProudctRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
                return BadRequest();

            try
            {
                ProudctRepository.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                var obj = ProudctRepository.Get(id);
                if (obj==null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProudctRepository.Create(product);
            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = ProudctRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            ProudctRepository.Delete(product);
            return Ok(product);
        }
    }
}