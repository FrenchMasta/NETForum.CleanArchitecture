using Domain.Enums;
using Domain.Helpers;

namespace Application.DTOs;

// Show what a "sealed" class (Player) will do
//public sealed class PlayerDto : Player
//{
//}

public class PlayerDto
{
    public PlayerDto(long id, string firstName, string lastName, PlayerPosition playerPosition, int shirtNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PlayerPosition = EnumHelper.GetEnumDescription(playerPosition);
        ShirtNumber = shirtNumber;
    }

    public long Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public int ShirtNumber { get; }
    public string PlayerPosition { get; }
}