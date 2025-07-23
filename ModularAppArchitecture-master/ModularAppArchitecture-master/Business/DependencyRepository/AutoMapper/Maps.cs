using AutoMapper;
using Entities.Dtos;

namespace Business.DependencyRepository.AutoMapper;

public class Maps : Profile
{
    public Maps()
    {
        CreateMap<Task, TaskDto>().ReverseMap();
        CreateMap<Task, TaskCreateDto>().ReverseMap();
        CreateMap<Task, TaskUpdateDto>().ReverseMap();
    }
}