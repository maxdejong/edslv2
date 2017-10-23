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
    public class RoundsController : ApiController
    {
        private EDSL_dbEntities db = new EDSL_dbEntities();

        // GET: api/Rounds
        public IQueryable<Round> GetRounds()
        {
            return db.Rounds;
        }

        // GET: api/Rounds/5
        [ResponseType(typeof(Round))]
        public IHttpActionResult GetRound(string id)
        {
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return NotFound();
            }

            return Ok(round);
        }

        // PUT: api/Rounds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRound(string id, Round round)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != round.roundID)
            {
                return BadRequest();
            }

            db.Entry(round).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundExists(id))
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

        // POST: api/Rounds
        [ResponseType(typeof(Round))]
        public IHttpActionResult PostRound(Round round)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rounds.Add(round);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoundExists(round.roundID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = round.roundID }, round);
        }

        // DELETE: api/Rounds/5
        [ResponseType(typeof(Round))]
        public IHttpActionResult DeleteRound(string id)
        {
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return NotFound();
            }

            db.Rounds.Remove(round);
            db.SaveChanges();

            return Ok(round);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundExists(string id)
        {
            return db.Rounds.Count(e => e.roundID == id) > 0;
        }
    }
}