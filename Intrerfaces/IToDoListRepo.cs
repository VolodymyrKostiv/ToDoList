using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.DL
{
    public interface IToDoListRepo
    {
        bool SaveChanges();

        IEnumerable<Job> GetAllJobs();
        Job GetJobById(int id);
        void CreateJob(Job job);
        void UpdateJob(Job job);
        void DeleteJob(Job job);
    }
}
