using Domain.Enums;
using Domain.Models;

namespace Infrastructure.SacrificesToDemoGods.MockDatabase;

public static class MockPlayerProvider
{
    public static Player AddPlayer(long id, string firstName, string lastName, PlayerPosition playerPosition, int shirtNumber)
    {
        return new Player
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            PlayerPosition = playerPosition,
            ShirtNumber = shirtNumber
        };
    }
}