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
    public class SeasonsController : ApiController
    {
        private EDSLEntities db = new EDSLEntities();

        // GET: api/Seasons
        public IQueryable<Season> GetSeasons()
        {
            return db.Seasons;
        }

        // GET: api/Seasons/5
        [ResponseType(typeof(Season))]
        public IHttpActionResult GetSeason(int id)
        {
            Season season = db.Seasons.Find(id);
            if (season == null)
            {
                return NotFound();
            }

            return Ok(season);
        }

        // PUT: api/Seasons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeason(int id, Season season)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != season.seasonID)
            {
                return BadRequest();
            }

            db.Entry(season).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(id))
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

        // POST: api/Seasons
        [ResponseType(typeof(Season))]
        public IHttpActionResult PostSeason(Season season)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Seasons.Add(season);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SeasonExists(season.seasonID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = season.seasonID }, season);
        }

        // DELETE: api/Seasons/5
        [ResponseType(typeof(Season))]
        public IHttpActionResult DeleteSeason(int id)
        {
            Season season = db.Seasons.Find(id);
            if (season == null)
            {
                return NotFound();
            }

            db.Seasons.Remove(season);
            db.SaveChanges();

            return Ok(season);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeasonExists(int id)
        {
            return db.Seasons.Count(e => e.seasonID == id) > 0;
        }
    }
}