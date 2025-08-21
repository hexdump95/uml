using System.Text.Json;

using AutoMapper;

using MantraUML.Application.Dtos;
using MantraUML.Domain.Entities;

namespace MantraUML.Application.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Project, ProjectResponse>();

        CreateMap<Diagram, DiagramResponse>();

        CreateMap<Class, ClassResponse>()
            .ForMember(dest => dest.Attributes,
                opt =>
                    opt.MapFrom(src => DeserializeToAttributeResponse(src.Attributes!))
            )
            .ForMember(dest => dest.Position,
                opt =>
                    opt.MapFrom(src => src)
            )
            .ForMember(dest => dest.Position,
                opt =>
                    opt.MapFrom(src => src)
            );

        CreateMap<Class, PositionResponse>()
            .ForMember(dest => dest.X,
                opt =>
                    opt.MapFrom(src => src.PositionX))
            .ForMember(dest => dest.Y,
                opt =>
                    opt.MapFrom(src => src.PositionY))
            ;

        CreateMap<Link, LinkResponse>();

        CreateMap<Diagram, DiagramDetailResponse>()
            .ForMember(dest => dest.Classes,
                opt =>
                    opt.MapFrom(src => src.Elements.Where(e => e is Class).ToList())
            ).ForMember(dest => dest.Links,
                opt =>
                    opt.MapFrom(src => src.Elements.Where(e => e is Link).ToList())
            );
    }

    private List<AttributeResponse> DeserializeToAttributeResponse(string src)
    {
        return JsonSerializer.Deserialize<List<AttributeResponse>>(src)!;
    }
}
