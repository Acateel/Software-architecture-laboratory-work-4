﻿using System;
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