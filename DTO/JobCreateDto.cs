using System;

namespace ToDoList.DTO
{
    public class JobCreateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string WhoAssigned { get; set; }

        public string AssignedTo { get; set; }

        public DateTime? DateOfAssigning { get; set; }

        public DateTime DueToDate { get; set; }
    }
}
