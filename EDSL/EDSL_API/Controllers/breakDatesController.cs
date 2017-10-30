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
    public class breakDatesController : ApiController
    {
        private EDSL_dbEntities db = new EDSL_dbEntities();

        // GET: api/breakDates
        public IQueryable<breakDate> GetbreakDates()
        {
            return db.breakDates;
        }

        // GET: api/breakDates/5
        [ResponseType(typeof(breakDate))]
        public IHttpActionResult GetbreakDate(int id)
        {
            breakDate breakDate = db.breakDates.Find(id);
            if (breakDate == null)
            {
                return NotFound();
            }

            return Ok(breakDate);
        }

        // PUT: api/breakDates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutbreakDate(int id, breakDate breakDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != breakDate.breakID)
            {
                return BadRequest();
            }

            db.Entry(breakDate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!breakDateExists(id))
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

        // POST: api/breakDates
        [ResponseType(typeof(breakDate))]
        public IHttpActionResult PostbreakDate(breakDate breakDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.breakDates.Add(breakDate);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (breakDateExists(breakDate.breakID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = breakDate.breakID }, breakDate);
        }

        // DELETE: api/breakDates/5
        [ResponseType(typeof(breakDate))]
        public IHttpActionResult DeletebreakDate(int id)
        {
            breakDate breakDate = db.breakDates.Find(id);
            if (breakDate == null)
            {
                return NotFound();
            }

            db.breakDates.Remove(breakDate);
            db.SaveChanges();

            return Ok(breakDate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool breakDateExists(int id)
        {
            return db.breakDates.Count(e => e.breakID == id) > 0;
        }
    }
}