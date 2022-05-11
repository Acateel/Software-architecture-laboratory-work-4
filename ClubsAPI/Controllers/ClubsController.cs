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
using Entities.Clubs;
using UnitOfWork;
using BusinessLogic;
using ClubsAPI.Models;

namespace ClubsAPI.Controllers
{
    public class ClubsController : ApiController
    {
        Logic logic;

        public ClubsController(Logic logic)
        {
            this.logic = logic;
        }

        // GET: api/Clubs
        public IQueryable<ClubModel> GetClubs()
        {
            return ClubsParser.GetClubsModel(logic.Clubs.GetClubs());
        }

        // GET: api/Clubs/5
        [ResponseType(typeof(ClubModel))]
        public IHttpActionResult GetClub(int id)
        {
            try
            {
                var club = logic.Clubs.SetClub(id);
                return Ok(ClubsParser.GetClubModel(club));
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Id not found");
            }
            
        }

        // PUT: api/Clubs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClub(int id, ClubModel clubModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Is not valid");
            }

            if (id != clubModel.Id)
            {
                return BadRequest();
            }

            var club = logic.Clubs.SetClub(id);
            ClubsParser.ChangeClubInfo(club, clubModel);
            logic.Club.ChangeInfo(club);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clubs
        [ResponseType(typeof(ClubModel))]
        public IHttpActionResult PostClub(ClubModel club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            logic.Clubs.CreateClub(ClubsParser.GetClub(club));

            return CreatedAtRoute("DefaultApi", new { id = club.Id }, club);
        }

        // DELETE: api/Clubs/5
        [ResponseType(typeof(Club))]
        public IHttpActionResult DeleteClub(int id)
        {
            Club club = logic.Clubs.SetClub(id);
            if (club == null)
            {
                return NotFound();
            }

            logic.Clubs.DeleteClub(id);

            return Ok(club);
        }
    }
}