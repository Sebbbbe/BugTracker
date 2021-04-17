
using BugTrackerNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
          var GetUserList =    _bugTrackerDBContext.Users.ToList();
            return GetUserList;

        }


        [HttpPost]
        public void AddUser([FromBody] User user)
        {
            _bugTrackerDBContext.Users.Add(user); // databasen table users läger vi till user user kommer från postman info vi lägger in
            _bugTrackerDBContext.SaveChanges();
        }


         [HttpDelete("{user_id:Guid}")]
         public void DeleteUser(Guid User_id)
         {
             var User = _bugTrackerDBContext.Users.Find(User_id); 
             _bugTrackerDBContext.Users.Remove(User);
             _bugTrackerDBContext.SaveChanges();
         } 

        

         [HttpPut("{user_id:Guid}")]
         public void UpdateUser ([FromBody] User user,  Guid user_id)
         {
            var userUpdate = _bugTrackerDBContext.Users.Find(user_id);
            
                 userUpdate.First_name = user.First_name;
                 userUpdate.Second_name = user.Second_name;
                 _bugTrackerDBContext.SaveChanges();
         }


        // en metod för att hämta 


        [HttpGet ("{id:Guid}")] // användaren ska göra /user som kommer från route sedan user_id
        // som jag säger här som ska vara av Guid /user/(guid_id)
        //det som är innuti http get måste ha samma namn som parametern vi kan kalla den test:guid tex
        // om vi ville
        public User GetUser(Guid id)
        {
           var GetOneUser = _bugTrackerDBContext.Users.FirstOrDefault(user => user.User_id == id);
            //hämtar ett  elementet när det som är innuti funktionen stämmer.
            //så när user_id är lika med det som användaren skriver in i postman user/guid_id
            //Get funktioner måste returnera något annars ser man inget
            // det som makes most sense är en User då vi gjorde List<User på första>

            return GetOneUser;

        }





    }
}
