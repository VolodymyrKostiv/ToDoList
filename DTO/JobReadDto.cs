using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DTO
{
    public class JobReadDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string AssignedTo { get; set; }

        public DateTime DateOfAssigning { get; set; }

        [Required]
        public DateTime DueToDate { get; set; }

        public JobStatus Status { get; set; }
    }
}
