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
    public class MatchesController : ApiController
    {
        private EDSL_dbEntities db = new EDSL_dbEntities();

        // GET: api/Matches
        public IQueryable<Match> GetMatches()
        {
            return db.Matches;
        }

        // GET: api/Matches/5
        [ResponseType(typeof(Match))]
        public IHttpActionResult GetMatch(string id)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // PUT: api/Matches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatch(string id, Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != match.matchID)
            {
                return BadRequest();
            }

            db.Entry(match).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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

        // POST: api/Matches
        [ResponseType(typeof(Match))]
        public IHttpActionResult PostMatch(Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Matches.Add(match);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MatchExists(match.matchID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = match.matchID }, match);
        }

        // DELETE: api/Matches/5
        [ResponseType(typeof(Match))]
        public IHttpActionResult DeleteMatch(string id)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return NotFound();
            }

            db.Matches.Remove(match);
            db.SaveChanges();

            return Ok(match);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatchExists(string id)
        {
            return db.Matches.Count(e => e.matchID == id) > 0;
        }
    }
}