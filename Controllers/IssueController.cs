using BugTrackerNew.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bugTrackerNew.Controllers
{
    [ApiController]
    [Route("Issue")]
    public class IssueController
    {
        private BugTrackerDBContext _bugTrackerDBContext;
        public IssueController(BugTrackerDBContext bugTrackerDBContext)
        {
            _bugTrackerDBContext = bugTrackerDBContext;
    
        }

        [HttpGet]

        public List<Issue> GetIssue ()
        {
            var GetIssue = _bugTrackerDBContext.Issues.ToList();
                return GetIssue;
        }

        [HttpPost]

        public void PostIssue(Issue issue)
        {
            _bugTrackerDBContext.Issues.Add(issue);
            _bugTrackerDBContext.SaveChanges();

        }

        [HttpDelete("{id:Guid}")]

        public void DeleteIssue(Guid id)
        {
            var DeleteIssue = _bugTrackerDBContext.Issues.Find(id); 
            _bugTrackerDBContext.Issues.Remove(DeleteIssue); 
            _bugTrackerDBContext.SaveChanges();

        }

        [HttpPut("{id:Guid}")]
        public void UpdateIssue(Guid id, Issue issue)
        {
            var UpdateIssue = _bugTrackerDBContext.Issues.Find(id);
            UpdateIssue.Summary = issue.Summary;
            UpdateIssue.Asignment = issue.Asignment;
            UpdateIssue.Category = issue.Category;
            UpdateIssue.Description = issue.Description;
            UpdateIssue.Priority = issue.Priority;
            UpdateIssue.Status = issue.Status;
            UpdateIssue.Asigned_to = issue.Asigned_to;
            UpdateIssue.Picture = issue.Picture;
            UpdateIssue.Date_created = issue.Date_created;
            UpdateIssue.due_date = issue.due_date;
            UpdateIssue.Completed_date = issue.Completed_date;
           



            _bugTrackerDBContext.SaveChanges();
        }
    }

}
