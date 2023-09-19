using Application.Mappings;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;

namespace Application.DTOs;

// Show what a "sealed" class (Player) will do
//public sealed class PlayerDto : Player
//{
//}

public class PlayerDto : IMapFrom<Player>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ShirtNumber { get; set; }
    public string PlayerPosition { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Player, PlayerDto>()
            .ForMember(destination => destination.PlayerPosition,
                options =>
                    options.MapFrom(source => EnumHelper.GetEnumDescription(source.PlayerPosition)));
    }
}