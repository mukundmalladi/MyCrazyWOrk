using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTrial2.Models;

namespace WebApiTrial2.Controllers
{
    public class Default1Controller : ApiController
    {
        private readonly WebApiTrial2Context db = new WebApiTrial2Context();

        // GET api/Default1
        public IEnumerable<Person> GetPersons()
        {

            return db.Persons.ToList();
        }

        // GET api/Default1/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            Person person = await db.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT api/Default1/5
        public async Task<IHttpActionResult> PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.BusinessEntityID)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST api/Default1
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persons.Add(person);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = person.BusinessEntityID }, person);
        }

        // DELETE api/Default1/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            Person person = await db.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.Persons.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.Persons.Count(e => e.BusinessEntityID == id) > 0;
        }
    }
}