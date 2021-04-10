using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  BugTrackerNew.Models

{
    public class Comment
    {
        //varje comment har en user och vilket issue den är i 
        //så comment är dependent till user och 
        //comment dependent entity till Issue
        public Guid Comment_id{ get; set; }
        public string Comment_text { get; set; }

        //comment behöver information av vilken user
       
        // sedan för att skapa relationen till comment behöver vi göra dependent
        //entity på comment
        public User User { get; set; }
        public Guid User_id { get; set; }

        // nu är user klar dags för issue comment dependent av issue

        public Guid Post_id { get; set; }
        public Issue Issue { get; set; } 


     
    }
}
