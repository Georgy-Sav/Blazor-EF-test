using System.Collections.Generic;
using PerfGUI.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace PerfGUI.Server.Controllers
{
    public class EnvironmentController : ControllerBase
    {
        IEnvironmentAccessLayer _environment;
        public EnvironmentController(IEnvironmentAccessLayer environment)
        {
            _environment = environment;
        }

        [HttpGet]
        [Route("api/Environment/Index")]
        public IEnumerable<Environment> Index()
        {
            return _environment.GetAllEnvironments();
        }

        [HttpPost]
        [Route("api/Environment/Create")]
        public void Create([FromBody]Environment environment)
        {
            if (ModelState.IsValid)
                this._environment.AddEnvironment(environment);
        }

        [HttpGet]
        [Route("api/Environment/Details/{id}")]
        public Environment Details(int id)
        {
            return _environment.GetEnvironmentData(id);
        }

        [HttpPut]
        [Route("api/Environment/Edit")]
        public void Edit([FromBody]Environment environment)
        {
            if (ModelState.IsValid)
                this._environment.UpdateEnvironment(environment);
        }

        [HttpDelete]
        [Route("api/Environment/Delete/{id}")]
        public void Delete(int id)
        {
            _environment.DeleteEnvironment(id);
        }
    }
}