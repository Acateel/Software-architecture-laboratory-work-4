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
        public IQueryable<String> GetClubs()
        {
            List<String> lines = new List<string>();
            foreach(var club in logic.Clubs.GetClubs())
            {
                lines.Add(club.ToString());
            }
            return lines.AsQueryable<string>();
        }

        //// GET: api/Clubs/5
        //[ResponseType(typeof(Club))]
        //public IHttpActionResult GetClub(int id)
        //{
        //    Club club = db.Clubs.Find(id);
        //    if (club == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(club);
        //}

        //// PUT: api/Clubs/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutClub(int id, Club club)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != club.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(club).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClubExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Clubs
        //[ResponseType(typeof(Club))]
        //public IHttpActionResult PostClub(Club club)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Clubs.Add(club);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = club.Id }, club);
        //}

        //// DELETE: api/Clubs/5
        //[ResponseType(typeof(Club))]
        //public IHttpActionResult DeleteClub(int id)
        //{
        //    Club club = db.Clubs.Find(id);
        //    if (club == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Clubs.Remove(club);
        //    db.SaveChanges();

        //    return Ok(club);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ClubExists(int id)
        //{
        //    return db.Clubs.Count(e => e.Id == id) > 0;
        //}
    }
}