using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities.Clubs;
using Entities.TimeTables;
using UnitOfWork;
using BusinessLogic;
using ClubsAPI.Models;
using Entities.Carts;

namespace ClubsAPI.Controllers
{
    public class ClubController : ApiController
    {
        Logic logic;

        public ClubController(Logic logic)
        {
            this.logic = logic;
        }

        // GET: api/Club/5
        public IHttpActionResult GetVisit(int id, int cartId)
        {
            if (!SelectionClub(id))
            {
                return BadRequest("Club Id not found");
            }

            if(cartId == 0)
            {
                return VisitWithoutCart();
            }
            else
            {
                return VisitWithCart(cartId);
            }
        }

        // POST: api/Club
        public IHttpActionResult PostByCart(int id, string type, TimeTable table)
        {

            if (!SelectionClub(id))
            {
                return BadRequest("Club Id not found");
            }

            Cart cart;
            switch (type)
            {
                case "Club":
                    cart = logic.Club.BuyClubCart(table);
                    break;
                case "Special":
                    cart = logic.Club.BuySpecialCart(table);
                    break;
                default:
                    return BadRequest("Type not found : " + type);
            }
            return Ok(cart);
        }

        // PUT: api/Club/5
        public IHttpActionResult PutSingUp(int id, int cartId, int time)
        {
            if (!SelectionClub(id))
            {
                return BadRequest("Club Id not found");
            }

            if (cartId == 0)
            {
                var cart = logic.Club.SingUp(time);
                return Ok(cart);
            }
            else
            {
                return SingUpWithCart(cartId, time);
            }
        }

        private bool SelectionClub(int id)
        {
            try
            {
                logic.Clubs.SetClub(id);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        private IHttpActionResult SingUpWithCart(int cartId, int time)
        {
            Cart cart;
            try
            {
                cart = logic.Carts.GetCart(cartId);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Cart Id not found");
            }
            bool singing = logic.Club.SingUp(cart, time);
            return Ok(singing);
        }

        private IHttpActionResult VisitWithoutCart()
        {
            try
            {
                logic.Club.VisitClub();
                return Ok("How you visit club without cart?");
            }
            catch(ClubException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private IHttpActionResult VisitWithCart(int cartId)
        {
            Cart cart;
            try
            {
                cart = logic.Carts.GetCart(cartId);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Cart Id not found");
            }
            bool visiting = logic.Club.VisitClub(cart);
            return Ok(visiting);
        }
    }
}
