using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Data
{
    public interface IToDoList
    {
        bool SaveChanges();

        IEnumerable<Job> GetAllJobs();
        Job GetJobById(int id);
        void CreateJob(Job job);
        void UpdateJob(Job job);
        void DeleteJob(Job job);
    }
}
