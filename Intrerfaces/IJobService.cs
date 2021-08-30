using System.Collections.Generic;
using ToDoList.DTO;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IJobService
    {
        IEnumerable<Job> GetAllJobs();
        Job GetJobById(int id);
        Job CreateJob(JobCreateDto job);
        bool UpdateJob(JobUpdateDto job, int id);
        bool DeleteJob(int id);
    }
}
