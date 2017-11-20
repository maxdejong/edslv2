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
    public class LaddersController : ApiController
    {
        private EDSLEntities db = new EDSLEntities();

        // GET: api/Ladders
        public IQueryable<Ladder> GetLadders()
        {
            return db.Ladders;
        }

        // GET: api/Ladders/5
        [ResponseType(typeof(Ladder))]
        public IHttpActionResult GetLadder(int id)
        {
            Ladder ladder = db.Ladders.Find(id);
            if (ladder == null)
            {
                return NotFound();
            }

            return Ok(ladder);
        }

        // PUT: api/Ladders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLadder(int id, Ladder ladder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ladder.LadderId)
            {
                return BadRequest();
            }

            db.Entry(ladder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LadderExists(id))
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

        // POST: api/Ladders
        [ResponseType(typeof(Ladder))]
        public IHttpActionResult PostLadder(Ladder ladder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ladders.Add(ladder);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LadderExists(ladder.LadderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ladder.LadderId }, ladder);
        }

        // DELETE: api/Ladders/5
        [ResponseType(typeof(Ladder))]
        public IHttpActionResult DeleteLadder(int id)
        {
            Ladder ladder = db.Ladders.Find(id);
            if (ladder == null)
            {
                return NotFound();
            }

            db.Ladders.Remove(ladder);
            db.SaveChanges();

            return Ok(ladder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LadderExists(int id)
        {
            return db.Ladders.Count(e => e.LadderId == id) > 0;
        }
    }
}