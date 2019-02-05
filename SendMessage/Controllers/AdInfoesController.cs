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
using SMSSending.Models;

namespace SendMessage.Controllers
{
    public class AdInfoesController : ApiController
    {
        private MessagesSendingDbContext db = new MessagesSendingDbContext();

        // GET: api/AdInfoes
        public IQueryable<AdInfo> GetAdInfos()
        {
            return db.AdInfos;
        }

        // GET: api/AdInfoes/5
        [ResponseType(typeof(AdInfo))]
        public async Task<IHttpActionResult> GetAdInfo(int id)
        {
            AdInfo adInfo = await db.AdInfos.FindAsync(id);
            if (adInfo == null)
            {
                return NotFound();
            }

            return Ok(adInfo);
        }

        // PUT: api/AdInfoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdInfo(int id, AdInfo adInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(adInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdInfoExists(id))
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

        // POST: api/AdInfoes
        [ResponseType(typeof(AdInfo))]
        public async Task<IHttpActionResult> PostAdInfo(AdInfo adInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdInfos.Add(adInfo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdInfoExists(adInfo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adInfo.Id }, adInfo);
        }

        // DELETE: api/AdInfoes/5
        [ResponseType(typeof(AdInfo))]
        public async Task<IHttpActionResult> DeleteAdInfo(int id)
        {
            AdInfo adInfo = await db.AdInfos.FindAsync(id);
            if (adInfo == null)
            {
                return NotFound();
            }

            db.AdInfos.Remove(adInfo);
            await db.SaveChangesAsync();

            return Ok(adInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdInfoExists(int id)
        {
            return db.AdInfos.Count(e => e.Id == id) > 0;
        }
    }
}