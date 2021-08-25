using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class SqlToDoList : IToDoList
    {
        private readonly ToDoListContext _context;

        public SqlToDoList(ToDoListContext context)
        {
            _context = context;
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }

        public Job GetJobById(int id)
        {
            return _context.Jobs.FirstOrDefault(i => i.Id == id);
        }
    }
}
