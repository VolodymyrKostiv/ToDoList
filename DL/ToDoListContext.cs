using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.DL
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> opt) : base(opt) { }

        public DbSet<Job> Jobs { get; set; }
    }
}
