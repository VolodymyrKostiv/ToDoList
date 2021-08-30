using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.DTO;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    //      api/jobs
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public JobsController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        //GET api/jobs
        [HttpGet]
        public ActionResult<IEnumerable<JobReadDto>> GetAllJobs()
        {
            IEnumerable <Job> jobs = _jobService.GetAllJobs();

            return Ok(_mapper.Map<IEnumerable<JobReadDto>>(jobs));
        }

        //GET api/jobs/{id}
        [HttpGet("{id}", Name = "GetJobById")]
        public ActionResult<JobReadDto> GetJobById(int id)
        {
            Job job = _jobService.GetJobById(id);

            return (job != null) ? Ok(_mapper.Map<JobReadDto>(job)) : NotFound();
        }

        //POST api/jobs
        [HttpPost]
        public ActionResult<JobReadDto> CreateJob(JobCreateDto jobCreateDto)
        {
            Job jobModel = _jobService.CreateJob(jobCreateDto);

            JobReadDto jobReadDto = _mapper.Map<JobReadDto>(jobModel);

            return CreatedAtRoute(nameof(GetJobById), new { Id = jobReadDto.Id }, jobReadDto);
        }

        //PUT api/jobs/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateJob(int id, JobUpdateDto jobUpdateDto)
        {
            if(jobUpdateDto == null)
            {
                return NotFound();
            }

            _jobService.UpdateJob(jobUpdateDto, id);

            return NoContent();
        }

        //DELETE api/jobs/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteJob(int id)
        {
            return _jobService.DeleteJob(id) ? NoContent() : NotFound();
        }
    }
}
