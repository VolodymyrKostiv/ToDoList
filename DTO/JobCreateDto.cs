using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DTO
{
    public class JobCreateDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string AssignedTo { get; set; }

        [Required]
        public DateTime DueToDate { get; set; }

        public JobStatus Status { get; set; }
    }
}
