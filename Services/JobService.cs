using AutoMapper;
using System;
using System.Collections.Generic;
using ToDoList.DL;
using ToDoList.DTO;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class JobService : IJobService
    {
        private readonly IToDoListRepo _doList;
        private readonly IMapper _mapper;

        public JobService(IToDoListRepo doList, IMapper mapper)
        {
            _doList = doList;
            _mapper = mapper;
        }

        public Job CreateJob(JobCreateDto job)
        {
            if(job == null)
            {
                return null;
            }

            Job jobModel = _mapper.Map<Job>(job);

            if (job.DateOfAssigning == null)
            {
                jobModel.DateOfAssigning = DateTime.UtcNow;
            }
            
            if (jobModel.DateOfAssigning > job.DueToDate)
            {
                return null;
            }

            jobModel.Status = JobStatus.Waiting;

            _doList.CreateJob(jobModel);

            _doList.SaveChanges();
            
            return jobModel;
        }

        public bool DeleteJob(int id)
        {
            Job jobModel = _doList.GetJobById(id);
            if (jobModel == null)
            {
                return false;
            }

            _doList.DeleteJob(jobModel);

            _doList.SaveChanges();

            return true;
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _doList.GetAllJobs();
        }

        public Job GetJobById(int id)
        {
            return _doList.GetJobById(id);
        }

        public bool UpdateJob(JobUpdateDto jobUpdateDto, int id)
        {
            Job jobToUpdate = _doList.GetJobById(id);
            if (jobToUpdate == null)
            {
                return false;
            }
            if (jobUpdateDto.DateOfAssigning == null)
            {
                jobUpdateDto.DateOfAssigning = DateTime.UtcNow;
            }
            if (jobUpdateDto.DateOfAssigning > jobUpdateDto.DueToDate)
            {
                return false;
            }

            _mapper.Map(jobUpdateDto, jobToUpdate);

            _doList.UpdateJob(jobToUpdate);

            _doList.SaveChanges();

            return true;
        }
    }
}
