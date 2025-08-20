using AutoMapper;

using MantraUML.Application.Dtos;
using MantraUML.Domain.Entities;

namespace MantraUML.Application.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Project, ProjectResponse>();
    }
}
