
using BugTrackerNew.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bugTrackerNew.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private BugTrackerDBContext _bugTrackerDBContext; // skapar en variabel som ska 
        // vara lika med databasen eller det som finns inne i dbcontext förstår inte exakt men det är för att vi ska
        // kunna ändra saker i databasen

        // vi använder oss av dependency injection
        // vi vill att controller ska vara beroende av DBContext
        // så vi säger att våran ctor måste ha en BugTrackerDBContext 

        public UserController(BugTrackerDBContext bugTrackerDBContext) 
        {
            _bugTrackerDBContext = bugTrackerDBContext;
        }
       
        [HttpGet]
        public List<User> GetUser()

        {
            var users = _bugTrackerDBContext.Users.ToList();
            return users;


        }


        [HttpPost]
        public void AddUser([FromBody] User user)
        {
            _bugTrackerDBContext.Users.Add(user); // databasen table users läger vi till user user kommer från postman info vi lägger in
            _bugTrackerDBContext.SaveChanges();
        }


        [HttpDelete ("{user_id:Guid}")]
        public void DeleteUser(Guid User_id)
        {

            var User = _bugTrackerDBContext.Users.Find(User_id);
            _bugTrackerDBContext.Users.Remove(User);
            _bugTrackerDBContext.SaveChanges();

            
        }
    }
    }

