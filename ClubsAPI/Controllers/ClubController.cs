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



        // GET: api/Club
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Club/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Club
        public IHttpActionResult PostByCart(int id, string type, TimeTable table)
        {
            try
            {
                logic.Clubs.SetClub(id);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Id not found");
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
            try
            {
                logic.Clubs.SetClub(id);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Club Id not found");
            }

            if(cartId == 0)
            {
                var cart = logic.Club.SingUp(time);
                return Ok(cart);
            }
            else
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
        }
    }
}
