using BugTrackerNew.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;




namespace bugTrackerNew
{
    // det blir en dbcontext klas när vi ärver från dbcontext
    //för att kunna använda querys , insert update delete etc behövs en dbcontext klass
    public class BugTrackerDBContext : DbContext
    {
        //skapar en instans av dbcontextoption för att context klassen ska kunna göra viktiga saker tex
        //tex vilken connection string man ska använda
        // Vi överför options till dbcontext genom :base (options)
        public BugTrackerDBContext(DbContextOptions<BugTrackerDBContext> options) 
            :base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //issue har primary key post.id
            modelBuilder
                .Entity<Issue>()
                .HasKey(issue => issue.Post_id);
            //en issue har en user medans en user har flera issues
            modelBuilder
                .Entity<Issue>()
                .HasOne(issue => issue.User)
                .WithMany(user => user.Issues)
                .HasForeignKey(issue => issue.User_id)
                .HasForeignKey(Issue => Issue.Project_id);





            // ---- issue klar

            // en user har många comments och en comment has en user
            modelBuilder
                .Entity<User>()
                .HasKey(User => User.User_id);

            modelBuilder
                .Entity<User>()
                .HasMany(user => user.Comments)
                .WithOne(Comment => Comment.User);
                
                

            // ---- user klar

            //project
            //En project har många issues , en issue har en project 
            modelBuilder
                .Entity<Project>()
                .HasKey(project => project.Project_id);

            modelBuilder
               .Entity<Project>()
               .HasMany(project => project.Issues)
               .WithOne(Issue => Issue.Project);



            // ---- project klar




            // comment 
            // en comment har ett issue medans en issue har många comments
            modelBuilder
                .Entity<Comment>()
                .HasKey(comment => comment.Comment_id);

            modelBuilder
               .Entity<Comment>()
               .HasOne(comment => comment.Issue)
               .WithMany(issue => issue.Comments);
               
               







            base.OnModelCreating(modelBuilder); 
        }

        //dbset används för att kunna använda sig av crud create, read, update, and delete 


        //nu kan vi använda crud med users 
        //Users Comments är vad Table namnet kommer kallas
        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Issue> Issues { get; set; }

    }
}
