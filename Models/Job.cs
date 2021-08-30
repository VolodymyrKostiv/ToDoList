using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string WhoAssigned { get; set; }

        [Required]
        [MaxLength(50)]
        public string AssignedTo { get; set; }

        [Required]
        public DateTime DateOfAssigning { get; set; }

        [Required]
        public DateTime DueToDate { get; set; }

        [Required]
        public JobStatus Status { get; set; }
    }
}
