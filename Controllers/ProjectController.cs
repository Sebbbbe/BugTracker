using BugTrackerNew.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bugTrackerNew.Controllers
{
    [ApiController]
    [Route("project")]
    public class ProjectController 
    {
        private BugTrackerDBContext _bugTrackerDBContext;
        public ProjectController(BugTrackerDBContext bugTrackerDBContext)
        {
            _bugTrackerDBContext = bugTrackerDBContext;
        }


        [HttpGet]
        public List<Project> GetProject()
        {
         var GetProjects = _bugTrackerDBContext.Projects.ToList();
            return GetProjects;
        }

        [HttpPost]

        public void CreateProject(Project project )
        {
           _bugTrackerDBContext.Projects.Add(project);
            _bugTrackerDBContext.SaveChanges();
        }

        [HttpDelete("{id:Guid}")]

        public void DeleteProject(Guid id)
        {
          var DeleteProject =_bugTrackerDBContext.Projects.Find(id);
            _bugTrackerDBContext.Projects.Remove(DeleteProject);
            _bugTrackerDBContext.SaveChanges();
        }

        [HttpPut("{id:Guid}")]
        public void UpdateProject(Guid id, Project project)
        {
            var updateProject = _bugTrackerDBContext.Projects.Find(id);
            updateProject.Project_Name = project.Project_Name;
            _bugTrackerDBContext.SaveChanges();
        }
    }


}
