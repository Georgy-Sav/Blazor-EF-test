using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PerfGUI.Server.DataAccess
{
    public interface IProjectAccessLayer
    {
        IEnumerable<Project> GetAllProjects();
        void AddProject(Project project);
        void UpdateProject(Project project);
        Project GetProjectData(long id);
        void DeleteProject(long id);
    }

    public class ProjectAccessLayer : IProjectAccessLayer
    {
        private PerfGUIContext _context;
        public ProjectAccessLayer(PerfGUIContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            try
            {
                return _context.Projects.ToList();
            }
            catch
            {
                return new List<Project>();
            }
        }

        public void AddProject (Project project)
        {
            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
            }
            catch { throw; }
        }

        public void UpdateProject(Project project)
        {
            try
            {
                _context.Entry(project).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch { throw; }
        }

        public Project GetProjectData(long id)
        {
            try
            {
                Project project = _context.Projects.Find(id);
                return project;
            }
            catch { throw; }
        }

        public void DeleteProject(long id)
        {
            try
            {
                var project = GetProjectData(id);
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
            catch { throw; }
        }
    }
}