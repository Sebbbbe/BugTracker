using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerNew.Models
{
    public class Issue
    {
        // relation med comment / user / project
        public Guid Post_id { get; set; }
        public string Asignment { get; set; }
        public string Summary { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public int Priority { get; set; }
        public string Status { get; set; }
        public string Asigned_to { get; set; }
        public string Picture { get; set; }

      

        public DateTime Date_created { get; set; }
        public DateTime due_date { get; set; }
        public DateTime Completed_date { get; set; }

      
        //dependent entity nu har jag skapat en länk mellan primary 
        // och foreign key
        public Guid? User_id { get; set; }
        // en issue har med all information som finns i user

        public User User { get; set; }

        // skapar en dependent entity genom project_id

        public Guid? Project_id { get; set; }

        //Allt i project behövs i issue för att veta i vilket
        //projekt "folder" den ska vara i
        public Project Project { get; set; }


        // varje issue har comments som man kan se
      public List<Comment> Comments { get; set; }
    }
}
