using System;
using ToDoList.Models;

namespace ToDoList.DTO
{
    public class JobUpdateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string WhoAssigned { get; set; }

        public string AssignedTo { get; set; }

        public DateTime? DateOfAssigning { get; set; }

        public DateTime DueToDate { get; set; }

        public JobStatus Status { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Job job)
            {
                return
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
            return (Title, Description, WhoAssigned, AssignedTo,
                DateOfAssigning, DueToDate, Status).GetHashCode();
        }
    }
}
