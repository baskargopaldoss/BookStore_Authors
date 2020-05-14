using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    // GET: api/User
    [HttpGet]
    public IEnumerable<User> Get()
    {
      return GetUsers();
    }

    // GET: api/User/5
    [HttpGet("{id}", Name = "Get")]
    public User Get(string id)
    {
      return GetUsers().Find(e => e.UserId == id);
    }

    // POST: api/User
    [HttpPost]
    [Produces("application/json")]
    public User Post([FromBody] User employee)
    {
      // Logic to create new Employee
      return new User();
    }

    // PUT: api/User/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] User employee)
    {
      // Logic to update an Employee
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }


    private List<User> GetUsers()
    {
      return new List<User>()
            {
                new User()
                {
                    UserId = "1",
                    FirstName= "John",
                    LastName = "Smith",
                    Email ="John.Smith@gmail.com",
                    Role = "Admin",
                    Password = "admin"
                },
                new User()
                {
                    UserId = "2",
                    FirstName= "Jane",
                    LastName = "Doe",
                    Email ="Jane.Doe@gmail.com",
                     Role = "Developer",
                    Password = "dev"
                }
            };
    }
  }
}