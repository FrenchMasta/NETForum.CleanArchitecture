using Application.DTOs;
using AutoMapper;
using Domain.Enums;
using Domain.Helpers;
using Domain.Models;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMappingProfileToPlayerDto();
        CreateMappingProfileToPlayer();
        CreateMappingProfileToTeamDto();
    }

    private void CreateMappingProfileToPlayerDto()
    {
        CreateMap<Player, PlayerDto>()
            .ForMember(destination => destination.PlayerPosition,
                options =>
                    options.MapFrom(source => EnumHelper.GetEnumDescription(source.PlayerPosition)));
    }

    private void CreateMappingProfileToPlayer()
    {
        CreateMap<PlayerDto, Player>()
            .ForMember(destination => destination.PlayerPosition,
                options =>
                    options.MapFrom(source => EnumHelper.GetEnumValueFromDescription<PlayerPosition>(source.PlayerPosition)));
    }

    private void CreateMappingProfileToTeamDto()
    {
        CreateMap<Team, TeamDto>()
            .ForMember(destination => destination.Players,
                options => options.MapFrom(source => source.Players))
            .AfterMap((source, destination) => destination.SetTeamAlias());
    }
}