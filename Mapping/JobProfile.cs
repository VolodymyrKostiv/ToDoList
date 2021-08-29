using AutoMapper;
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
