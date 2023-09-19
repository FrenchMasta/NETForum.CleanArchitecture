using Application.Mappings;
using AutoMapper;
using Domain.Models;

namespace Application.DTOs;

public class TeamDto : IMapFrom<Team>
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string KnownAs { get; private set; }
    public List<PlayerDto> Players { get; private set; }

    private void SetTeamAlias()
    {
        KnownAs = Name switch
        {
            "Manchester United" => "Red Devils",
            "Arsenal" => "The Gunners",
            "Chelsea" => "The Blues",
            "Liverpool" => "Need to keep this PG13 - Just call them kak",
            _ => Name
        };
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Team, TeamDto>()
            .ForMember(destination => destination.Players, 
                options => options.MapFrom(source => source.Players))
            .AfterMap((source, destination) => destination.SetTeamAlias());
    }
}