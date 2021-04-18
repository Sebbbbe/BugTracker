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
    [Route("Comment")]
    public class CommentController : ControllerBase
    {

        private BugTrackerDBContext _bugTrackerDBContext;
        public CommentController(BugTrackerDBContext bugTrackerDBContext)
        {
            _bugTrackerDBContext = bugTrackerDBContext;
        }

        [HttpGet]
        public List<Comment> GetComment()
        {
            var comment = _bugTrackerDBContext.Comments.ToList();
            return comment;

        }

        [HttpPost]
        public void UpdateComment(Comment comment )
        {
          
            _bugTrackerDBContext.Comments.Add(comment);  
            _bugTrackerDBContext.SaveChanges();

        }

        [HttpDelete ("{id:Guid}")] 

        public void DeleteComment(Guid id )
        {
           var DeleteComment =  _bugTrackerDBContext.Comments.Find(id); // går till dbset comments som sedan kollar i comment efter id
            _bugTrackerDBContext.Comments.Remove(DeleteComment); // deletar comment med id som sätts in
            _bugTrackerDBContext.SaveChanges();

        }

        [HttpPut ("{id:Guid}")]

        public void UpdateComment(Guid id , Comment comment)
        {
        var UpdateComment = _bugTrackerDBContext.Comments.Find(id);

            UpdateComment.Comment_text = comment.Comment_text;
            _bugTrackerDBContext.SaveChanges();


        }


        [HttpGet("{id:Guid}/test")]
        public List<Comment> GetUserAndComments()
        {


            var a = _bugTrackerDBContext.Comments.Include(comment => comment.User).ToList();


            return a;
           

        }



    }
}
