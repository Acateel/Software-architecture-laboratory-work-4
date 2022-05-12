using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities.Carts;
using UnitOfWork;
using BusinessLogic;
using ClubsAPI.Models;

namespace ClubsAPI.Controllers
{
    public class CartController : ApiController
    {
        Logic logic;

        public CartController(Logic logic)
        {
            this.logic = logic;
        }



        // GET: api/Cart
        public IEnumerable<Cart> Get()
        {
            return logic.Carts.GetCarts().AsEnumerable<Cart>();
        }

        // GET: api/Cart/5
        public Cart Get(int id)
        {
            return logic.Carts.GetCart(id);
        }

        // POST: api/Cart
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cart/5
        public void Delete(int id)
        {
        }
    }
}
