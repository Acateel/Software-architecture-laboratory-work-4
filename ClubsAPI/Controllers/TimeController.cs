using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities.Timers;

namespace ClubsAPI.Controllers
{
    public class TimeController : ApiController
    {
        // GET: api/Time
        public int Get()
        {
            return ClasicTimer.GetTime();
        }

        // PUT: api/Time
        public IHttpActionResult Put(int time)
        {
            ClasicTimer.setTime(time);
            return Ok(time);
        }
    }
}
