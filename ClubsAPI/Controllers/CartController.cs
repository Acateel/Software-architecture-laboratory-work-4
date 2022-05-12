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
using Entities.TimeTables;

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
        public IEnumerable<Cart> GetCarts()
        {
            return logic.Carts.GetCarts().AsEnumerable<Cart>();
        }

        // GET: api/Cart/5
        public IHttpActionResult GetCart(int id)
        {
            try
            {
                var cart = logic.Carts.GetCart(id);
                return Ok(cart);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Id not found");
            }

        }

        // PUT: api/Cart/5
        public IHttpActionResult PutTimeTable(int id, TimeTable table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Is not valid");
            }

            try
            {
                logic.Carts.GetCart(id);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Id not found");
            }

            try
            {
                logic.Carts.ChangeTimeTable(id, table);
                return Ok(table);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Table did not change");
            }

        }

        // DELETE: api/Cart/5
        public IHttpActionResult DeleteCart(int id)
        {
            Cart cart;
            try
            {
                cart = logic.Carts.GetCart(id);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Id not found");
            }

            logic.Carts.RemoveCart(id);

            return Ok(cart);
        }
    }
}
