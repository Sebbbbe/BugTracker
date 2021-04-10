using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  BugTrackerNew.Models

{
    public class User
    {
        // user har relation med comment och issue

        // user kan skapa många issues därför är user primary (principal entity) och issue
        //dependent entity så gör en user_id i issue
        //Nu är det dags att ha issue med i User klassen
        // en user kan ha flera issues 
        public Guid User_id { get; set; }
        public string First_name { get; set; }
        public string Second_name { get; set; }

        // en user har flera issues och en issue har en user_id
        public List<Issue> Issues { get; set; }

       // ska jag göra List<Comment> comments
       // då kan jag spara alla comments i databasen
       // under vara user som jag senare kan hantera.
       // Det låter bra

        public List<Comment> Comments { get; set; }

     


    }
}
