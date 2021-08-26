using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.DTO;
using ToDoList.Models;

namespace ToDoList.Mapping
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobReadDto>();
            CreateMap<JobCreateDto, Job>();
            CreateMap<JobUpdateDto, Job>();
            CreateMap<Job, JobUpdateDto>();
        }
    }
}
