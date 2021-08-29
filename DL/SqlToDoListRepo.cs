using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.DL
{
    public class SqlToDoListRepo : IToDoListRepo
    {
        private readonly ToDoListContext _context;

        public SqlToDoListRepo(ToDoListContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateJob(Job job)
        {
            if(job is null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            _context.Jobs.Add(job);
        }

        public void DeleteJob(Job job)
        {
            if(job is null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            _context.Jobs.Remove(job);
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }

        public Job GetJobById(int id)
        {
            return _context.Jobs.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateJob(Job job)
        {
            //
        }
    }
}
