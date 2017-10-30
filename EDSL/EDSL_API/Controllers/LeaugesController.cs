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
using EDSL_API.Models;

namespace EDSL_API.Controllers
{
    public class LeaugesController : ApiController
    {
        private EDSL_dbEntities db = new EDSL_dbEntities();

        // GET: api/Leauges
        public IQueryable<Leauge> GetLeauges()
        {
            return db.Leauges;
        }

        // GET: api/Leauges/5
        [ResponseType(typeof(Leauge))]
        public IHttpActionResult GetLeauge(int id)
        {
            Leauge leauge = db.Leauges.Find(id);
            if (leauge == null)
            {
                return NotFound();
            }

            return Ok(leauge);
        }

        // PUT: api/Leauges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeauge(int id, Leauge leauge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leauge.leagueID)
            {
                return BadRequest();
            }

            db.Entry(leauge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaugeExists(id))
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

        // POST: api/Leauges
        [ResponseType(typeof(Leauge))]
        public IHttpActionResult PostLeauge(Leauge leauge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leauges.Add(leauge);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LeaugeExists(leauge.leagueID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = leauge.leagueID }, leauge);
        }

        // DELETE: api/Leauges/5
        [ResponseType(typeof(Leauge))]
        public IHttpActionResult DeleteLeauge(int id)
        {
            Leauge leauge = db.Leauges.Find(id);
            if (leauge == null)
            {
                return NotFound();
            }

            db.Leauges.Remove(leauge);
            db.SaveChanges();

            return Ok(leauge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaugeExists(int id)
        {
            return db.Leauges.Count(e => e.leagueID == id) > 0;
        }
    }
}