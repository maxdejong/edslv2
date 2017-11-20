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
    public class DrawsController : ApiController
    {
        private EDSLEntities db = new EDSLEntities();

        // GET: api/Draws
        public IQueryable<Draw> GetDraws()
        {
            return db.Draws;
        }

        // GET: api/Draws/5
        [ResponseType(typeof(Draw))]
        public IHttpActionResult GetDraw(int id)
        {
            Draw draw = db.Draws.Find(id);
            if (draw == null)
            {
                return NotFound();
            }

            return Ok(draw);
        }

        // PUT: api/Draws/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDraw(int id, Draw draw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != draw.drawID)
            {
                return BadRequest();
            }

            db.Entry(draw).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrawExists(id))
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

        // POST: api/Draws
        [ResponseType(typeof(Draw))]
        public IHttpActionResult PostDraw(Draw draw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Draws.Add(draw);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DrawExists(draw.drawID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = draw.drawID }, draw);
        }

        // DELETE: api/Draws/5
        [ResponseType(typeof(Draw))]
        public IHttpActionResult DeleteDraw(int id)
        {
            Draw draw = db.Draws.Find(id);
            if (draw == null)
            {
                return NotFound();
            }

            db.Draws.Remove(draw);
            db.SaveChanges();

            return Ok(draw);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrawExists(int id)
        {
            return db.Draws.Count(e => e.drawID == id) > 0;
        }
    }
}