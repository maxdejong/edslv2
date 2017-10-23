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
    public class ContactsController : ApiController
    {
        private EDSL_dbEntities db = new EDSL_dbEntities();

        // GET: api/Contacts
        public IQueryable<Contact> GetContacts()
        {
            return db.Contacts;
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(string id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(string id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.contactID)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ContactExists(contact.contactID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = contact.contactID }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(string id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(string id)
        {
            return db.Contacts.Count(e => e.contactID == id) > 0;
        }
    }
}