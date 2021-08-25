using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    //      api/jobs
    [Route("api/[controller")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IToDoList _doList;

        public JobsController(IToDoList doList)
        {
            _doList = doList;
        }

        //GET api/jobs
        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetAllJobs()
        {
            IEnumerable <Job> jobs = _doList.GetAllJobs();

            return Ok(jobs);
        }

        //GET api/jobs/{id}
        [HttpGet("{id}")]
        public ActionResult<Job> GetJobById(int id)
        {
            Job job = _doList.GetJobById(id);

            return Ok(job);
        }

        //POST api/jobs
        [HttpPost]

        //PUT api/jobs{id}
        [HttpPut("{id}")]

        //PATCH api/jobs/{id}
        [HttpPatch("{id}")]

        //DELETE api/jobs/{id}
        [HttpDelete("{id}")]

        public ActionResult<Job> DeleteJobById(int id)
        {
            return Ok();
        }

    }
}
