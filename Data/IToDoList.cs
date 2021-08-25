using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Data
{
    public interface IToDoList
    {
        IEnumerable<Job> GetAllJobs();
        Job GetJobById(int id);
    }
}
