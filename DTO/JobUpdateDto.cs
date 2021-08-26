﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DTO
{
    public class JobUpdateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string AssignedTo { get; set; }

        public DateTime DueToDate { get; set; }

        public JobStatus Status { get; set; }
    }
}
