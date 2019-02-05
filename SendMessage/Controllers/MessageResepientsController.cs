using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SMSSending;

namespace SendMessage.Controllers
{
    public class MessageResepientsController : ApiController
    {
        private MessagesSendingDbContext db = new MessagesSendingDbContext();

        // GET: api/MessageResepients
        public IQueryable<MessageResepient> GetMessageResepients()
        {
            return db.MessageResepients;
        }

        // GET: api/MessageResepients/5
        [ResponseType(typeof(MessageResepient))]
        public async Task<IHttpActionResult> GetMessageResepient(int id)
        {
            MessageResepient messageResepient = await db.MessageResepients.FindAsync(id);
            if (messageResepient == null)
            {
                return NotFound();
            }

            return Ok(messageResepient);
        }

        // PUT: api/MessageResepients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMessageResepient(int id, MessageResepient messageResepient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messageResepient.Id)
            {
                return BadRequest();
            }

            db.Entry(messageResepient).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageResepientExists(id))
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

        // POST: api/MessageResepients
        [ResponseType(typeof(MessageResepient))]
        public async Task<IHttpActionResult> PostMessageResepient(MessageResepient messageResepient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MessageResepients.Add(messageResepient);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MessageResepientExists(messageResepient.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = messageResepient.Id }, messageResepient);
        }

        // DELETE: api/MessageResepients/5
        [ResponseType(typeof(MessageResepient))]
        public async Task<IHttpActionResult> DeleteMessageResepient(int id)
        {
            MessageResepient messageResepient = await db.MessageResepients.FindAsync(id);
            if (messageResepient == null)
            {
                return NotFound();
            }

            db.MessageResepients.Remove(messageResepient);
            await db.SaveChangesAsync();

            return Ok(messageResepient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageResepientExists(int id)
        {
            return db.MessageResepients.Count(e => e.Id == id) > 0;
        }
    }
}