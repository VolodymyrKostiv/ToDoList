using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.DTO;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    //      api/jobs
    [Route("api/[controller")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IToDoList _doList;
        private readonly IMapper _mapper;

        public JobsController(IToDoList doList, IMapper mapper)
        {
            _doList = doList;
            _mapper = mapper;
        }

        //GET api/jobs
        [HttpGet]
        public ActionResult<IEnumerable<JobReadDto>> GetAllJobs()
        {
            IEnumerable <Job> jobs = _doList.GetAllJobs();

            return Ok(_mapper.Map<IEnumerable<JobReadDto>>(jobs));
        }

        //GET api/jobs/{id}
        [HttpGet("{id}", Name = "GetJobById")]
        public ActionResult<JobReadDto> GetJobById(int id)
        {
            Job job = _doList.GetJobById(id);

            return (job is not null) ? Ok(_mapper.Map<JobReadDto>(job)) : NotFound();
        }

        //POST api/jobs
        [HttpPost]
        public ActionResult<JobReadDto> CreateJob(JobCreateDto jobCreateDto)
        {
            Job jobModel = _mapper.Map<Job>(jobCreateDto);

            _doList.CreateJob(jobModel);

            _doList.SaveChanges();

            JobReadDto jobReadDto = _mapper.Map<JobReadDto>(jobModel);

            return CreatedAtRoute(nameof(GetJobById), new { Id = jobReadDto.Id }, jobReadDto);
        }

        //PUT api/jobs/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateJob(int id, JobUpdateDto jobUpdateDto)
        {
            Job jobModel = _doList.GetJobById(id);
            if(jobModel is null)
            {
                return NotFound();
            }

            _mapper.Map(jobUpdateDto, jobModel);

            _doList.UpdateJob(jobModel);

            _doList.SaveChanges();

            return NoContent();
        }

        //PATCH api/jobs/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialJobUpdate(int id, JsonPatchDocument<JobUpdateDto> jsonPatchDocument)
        {
            Job jobModel = _doList.GetJobById(id);
            if (jobModel is null)
            {
                return NotFound();
            }

            JobUpdateDto jobToPatch = _mapper.Map<JobUpdateDto>(jobModel);
            jsonPatchDocument.ApplyTo(jobToPatch, ModelState);
            if(!TryValidateModel(jobToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(jobToPatch, jobModel);

            _doList.UpdateJob(jobModel);

            _doList.SaveChanges();

            return NoContent();
        }

        //DELETE api/jobs/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteJob(int id)
        {
            Job jobModel = _doList.GetJobById(id);
            if (jobModel is null)
            {
                return NotFound();
            }

            _doList.DeleteJob(jobModel);

            _doList.SaveChanges();

            return NoContent();
        }

    }
}
