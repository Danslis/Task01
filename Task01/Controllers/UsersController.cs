using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Task01.Models;

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        TestDbContext db;
        public UsersController(TestDbContext context)
        {
            this.db = context;
            /*if (!db.User.Any())
            {
                db.User.Add(new Users { Id = 1, Name = "Tom", Age = 26 });
                db.User.Add(new Users { Id =2 ,Name = "Alice", Age = 31 });
                db.SaveChanges();
            }*/
        }

        [HttpGet]
        public IEnumerable<UserDepartmentTransaction> Get()
        {
            var partialResult = (from c in db.User
                                 join o in db.Department
                                 on c.DepartmentId equals o.Id
                                 select new UserDepartmentTransaction
                                 {
                                     Id = c.Id,
                                     UserName =c.UserName,
                                     DepartmentId = c.DepartmentId,
                                     Title = o.Title
                                 }).ToList(); 
            return partialResult;
        }

        

        // GET api/users/5
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        /*Users user = db.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
            return NotFound();
        return new ObjectResult(user);*/
        //}

        // POST api/users
        //[HttpPost]
        //public IActionResult Post([FromBody]Users user)
        //{
        /*if (user == null)
        {
            return BadRequest();
        }

        db.Users.Add(user);
        db.SaveChanges();
        return Ok(user);*/
        //}

        // PUT api/users/
        //[HttpPut]
        //public IActionResult Put([FromBody]Users user)
        //{
        /* if (user == null)
         {
             return BadRequest();
         }
         if (!db.Users.Any(x => x.Id == user.Id))
         {
             return NotFound();
         }

         db.Update(user);
         db.SaveChanges();
         return Ok(user);*/
        //}

        // DELETE api/users/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        /*Users user = db.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        db.Users.Remove(user);
        db.SaveChanges();
        return Ok(user);*/
        //}
    }
}