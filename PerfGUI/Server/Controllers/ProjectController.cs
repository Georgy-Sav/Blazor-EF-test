using System.Collections.Generic;
using PerfGUI.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace PerfGUI.Server.Controllers
{
    public class ProjectController : ControllerBase
    {
        IProjectAccessLayer _project;
        public ProjectController(IProjectAccessLayer project)
        {
            _project = project;
        }

        [HttpGet]
        [Route("api/Project/Index")]
        public IEnumerable<Project> Index()
        {
            return _project.GetAllProjects();
        }

        [HttpPost]
        [Route("api/Project/Create")]
        public void Create([FromBody]Project project)
        {
            if (ModelState.IsValid)
                this._project.AddProject(project);
        }

        [HttpGet]
        [Route("api/Project/Details/{id}")]
        public Project Details(int id)
        {
            return _project.GetProjectData(id);
        }

        [HttpPut]
        [Route("api/Project/Edit")]
        public void Edit([FromBody]Project project)
        {
            if (ModelState.IsValid)
                this._project.UpdateProject(project);
        }

        [HttpDelete]
        [Route("api/Project/Delete/{id}")]
        public void Delete(int id)
        {
            _project.DeleteProject(id);
        }
    }
}