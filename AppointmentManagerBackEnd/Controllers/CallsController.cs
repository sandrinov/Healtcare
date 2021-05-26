using AppointmentManagerBackEnd.Data;
using AppointmentsManagerShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagerBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallsController : ControllerBase
    {
        private CallManagerDbContext db;

        public CallsController(CallManagerDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.db.Calls.Select(x => new Call()
            {
                Id = x.Id,
                Name = x.Name,
                Provider = x.Provider,
                Date = x.Date
            }).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.db.Calls
                .Where(x => x.Id == id)
                .Select(x => new Call()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Provider = x.Provider,
                    Date = x.Date,
                    Description = x.Description,
                    Note = x.Note
                }).SingleOrDefault();

            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Call call = this.db.Calls.Where(c => c.Id == id).FirstOrDefault();
            this.db.Calls.Remove(call);
            this.db.SaveChanges();
            return Ok();
        }

    }
}
