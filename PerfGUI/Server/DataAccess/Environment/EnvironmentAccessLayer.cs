using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PerfGUI.Server.DataAccess
{
    public interface IEnvironmentAccessLayer
    {
        IEnumerable<Environment> GetAllEnvironments();
        void AddEnvironment(Environment env);
        void UpdateEnvironment(Environment env);
        Environment GetEnvironmentData(long id);
        void DeleteEnvironment(long id);
    }

    public class EnvironmentAccessLayer : IEnvironmentAccessLayer
    {
        private PerfGUIContext _context;
        public EnvironmentAccessLayer(PerfGUIContext context)
        {
            _context = context;
        }

        private bool CheckConnection()
        {
            try
            {
                _context.Database.OpenConnection();
                _context.Database.CloseConnection();
            }
            catch
            {
                System.Console.WriteLine("Database is not accessible!");
                return false;
            }
            System.Console.WriteLine("Database is OK.");
            return true;
        }

        public IEnumerable<Environment> GetAllEnvironments()
        {
            try
            {
                return _context.Environments
                    .Include(e => e.Project)
                    .ToList();
            }
            catch
            {
                return new List<Environment>();
            }
        }

        public void AddEnvironment (Environment env)
        {
            try
            {
                _context.Environments.Add(env);
                _context.SaveChanges();
            }
            catch { throw; }
        }

        public void UpdateEnvironment(Environment env)
        {
            try
            {
                _context.Entry(env).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch { throw; }
        }

        public Environment GetEnvironmentData(long id)
        {
            try
            {
                Environment env = (from e in _context.Environments.Include("Project")
                    where e.EnvironmentId == id
                    select e).FirstOrDefault<Environment>();
                // Environment env = _context.Environments
                //     .Where(e => e.EnvironmentId == id)
                //     .Include(e => e.Project)
                //     .FirstOrDefault();
                return env;
            }
            catch { throw; }
        }

        public void DeleteEnvironment(long id)
        {
            try
            {
                var env = GetEnvironmentData(id);
                _context.Environments.Remove(env);
                _context.SaveChanges();
            }
            catch { throw; }
        }
    }
}