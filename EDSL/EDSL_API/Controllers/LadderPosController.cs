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
    public class LadderPosController : ApiController
    {
        private EDSLEntities db = new EDSLEntities();

        // GET: api/LadderPos
        public IQueryable<LadderPos> GetLadderPos()
        {
            return db.LadderPos;
        }

        // GET: api/LadderPos/5
        [ResponseType(typeof(LadderPos))]
        public IHttpActionResult GetLadderPos(int id)
        {
            LadderPos ladderPos = db.LadderPos.Find(id);
            if (ladderPos == null)
            {
                return NotFound();
            }

            return Ok(ladderPos);
        }

        // PUT: api/LadderPos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLadderPos(int id, LadderPos ladderPos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ladderPos.LadderPosId)
            {
                return BadRequest();
            }

            db.Entry(ladderPos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LadderPosExists(id))
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

        // POST: api/LadderPos
        [ResponseType(typeof(LadderPos))]
        public IHttpActionResult PostLadderPos(LadderPos ladderPos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LadderPos.Add(ladderPos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LadderPosExists(ladderPos.LadderPosId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ladderPos.LadderPosId }, ladderPos);
        }

        // DELETE: api/LadderPos/5
        [ResponseType(typeof(LadderPos))]
        public IHttpActionResult DeleteLadderPos(int id)
        {
            LadderPos ladderPos = db.LadderPos.Find(id);
            if (ladderPos == null)
            {
                return NotFound();
            }

            db.LadderPos.Remove(ladderPos);
            db.SaveChanges();

            return Ok(ladderPos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LadderPosExists(int id)
        {
            return db.LadderPos.Count(e => e.LadderPosId == id) > 0;
        }
    }
}