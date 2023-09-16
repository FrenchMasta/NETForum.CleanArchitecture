using Domain.Models;

namespace Infrastructure.SacrificesToDemoGods.MockDatabase;

public static class MockTeamProvider
{
    public static Team AddTeam(long id, string name, List<Player> players)
    {
        return new Team
        {
            Id = id,
            Name = name,
            Players = players
        };
    }
}