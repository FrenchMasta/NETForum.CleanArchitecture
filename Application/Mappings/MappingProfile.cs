using Application.DTOs;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMappingProfileToPlayerDto();
        CreateMappingProfileToTeamDto();
    }

    private void CreateMappingProfileToPlayerDto()
    {
        CreateMap<Player, PlayerDto>()
            .ForMember(destination => destination.PlayerPosition,
                options =>
                    options.MapFrom(source => EnumHelper.GetEnumDescription(source.PlayerPosition)));
    }

    private void CreateMappingProfileToTeamDto()
    {
        CreateMap<Team, TeamDto>()
            .ForMember(destination => destination.Players,
                options => options.MapFrom(source => source.Players))
            .AfterMap((source, destination) => destination.SetTeamAlias());
    }
}