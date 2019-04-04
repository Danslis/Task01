using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Task01.Models;

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController1 : Controller
    {
        UsersContext db;
        public UsersController1(UsersContext context)
        {
            this.db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new Users1 { Id = 1, Name = "Tom", Age = 26 });
                db.Users.Add(new Users1 { Id =2 ,Name = "Alice", Age = 31 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Users1> Get()
        {
            return db.Users.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Users1 user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]Users1 user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public IActionResult Put([FromBody]Users1 user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            db.Update(user);
            db.SaveChanges();
            return Ok(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Users1 user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return Ok(user);
        }
    }
}