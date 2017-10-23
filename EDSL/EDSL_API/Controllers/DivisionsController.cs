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
    public class DivisionsController : ApiController
    {
        private EDSL_dbEntities db = new EDSL_dbEntities();

        // GET: api/Divisions
        public IQueryable<Division> GetDivisions()
        {
            return db.Divisions;
        }

        // GET: api/Divisions/5
        [ResponseType(typeof(Division))]
        public IHttpActionResult GetDivision(string id)
        {
            Division division = db.Divisions.Find(id);
            if (division == null)
            {
                return NotFound();
            }

            return Ok(division);
        }

        // PUT: api/Divisions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDivision(string id, Division division)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != division.divID)
            {
                return BadRequest();
            }

            db.Entry(division).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DivisionExists(id))
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

        // POST: api/Divisions
        [ResponseType(typeof(Division))]
        public IHttpActionResult PostDivision(Division division)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Divisions.Add(division);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DivisionExists(division.divID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = division.divID }, division);
        }

        // DELETE: api/Divisions/5
        [ResponseType(typeof(Division))]
        public IHttpActionResult DeleteDivision(string id)
        {
            Division division = db.Divisions.Find(id);
            if (division == null)
            {
                return NotFound();
            }

            db.Divisions.Remove(division);
            db.SaveChanges();

            return Ok(division);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DivisionExists(string id)
        {
            return db.Divisions.Count(e => e.divID == id) > 0;
        }
    }
}