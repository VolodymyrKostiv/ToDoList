﻿using System;
using ToDoList.Models;

namespace ToDoList.DTO
{
    public class JobReadDto : IEquatable<JobReadDto>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string WhoAssigned { get; set; }

        public string AssignedTo { get; set; }

        public DateTime DateOfAssigning { get; set; }

        public DateTime DueToDate { get; set; }

        public JobStatus Status { get; set; }

        public bool Equals(JobReadDto job)
        {
            if (job is null)
            {
                return false;
            }
            else
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
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as JobReadDto);
        }

        public override int GetHashCode()
        {
            return (Id, Title, Description, WhoAssigned, AssignedTo,
                DateOfAssigning, DueToDate, Status).GetHashCode();
        }
    }
}
