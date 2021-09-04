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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if(obj is Job job)
            {
                return
                    Id == job.Id &&
                    Title == job.Title &&
                    Description == job.Description &&
                    WhoAssigned == job.WhoAssigned &&
                    AssignedTo == job.AssignedTo &&
                    DateOfAssigning == job.DateOfAssigning &&
                    DueToDate == job.DueToDate &&
                    Status == job.Status;
            }   
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (Id, Title, Description, WhoAssigned, AssignedTo, 
                DateOfAssigning, DueToDate, Status).GetHashCode();
        }
    }
}
