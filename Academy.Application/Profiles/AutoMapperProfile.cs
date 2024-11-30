using Academy.Application.Dtos;
using Academy.Domain.Entities;
using AutoMapper;
using Core.Persistence.Paging;

namespace Academy.Application.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<StudentDto, Student>().ReverseMap();
        CreateMap<StudentCreateDto, Student>().ReverseMap();
        CreateMap<StudentUpdateDto, Student>().ReverseMap();
        CreateMap<Paginate<Student>, StudentListDto>().ReverseMap();
    }
}
