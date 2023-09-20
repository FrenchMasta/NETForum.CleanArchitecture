using Domain.Enums;
using Domain.Models;

namespace Infrastructure.SacrificesToDemoGods.MockDatabase;

public class MockDatabase
{
    public List<Player> Players { get; set; } = new();
    public List<Team> Teams { get; set; } = new();

    public MockDatabase()
    {
        SetupDatabase();
    }

    public void SaveChanges()
    {
        // do cool db things

        return;
    }

    private void SetupDatabase()
    {
        SetupPlayers();
        SetupTeams();
    }

    private void SetupPlayers()
    {
        Players.AddRange(SetupManUnitedPlayers());
        Players.AddRange(SetupArsenalPlayers());
    }

    private static List<Player> SetupManUnitedPlayers()
    {
        return new List<Player>
        {
            MockPlayerProvider.AddPlayer(15, "Nemanja", "Vidic", PlayerPosition.Defender, 15),
            MockPlayerProvider.AddPlayer(5, "Rio", "Ferdinand", PlayerPosition.Defender, 5),
            MockPlayerProvider.AddPlayer(7, "Cristiano", "Ronaldo", PlayerPosition.Forward, 7),
            MockPlayerProvider.AddPlayer(8, "Wayne", "Rooney", PlayerPosition.Forward, 8),
            MockPlayerProvider.AddPlayer(10, "Marcus", "Rashford", PlayerPosition.Forward, 10)
        };
    }

    private static List<Player> SetupArsenalPlayers()
    {
        return new List<Player>
        {
            MockPlayerProvider.AddPlayer(14, "Thierry", "Henry", PlayerPosition.Forward, 14),
            MockPlayerProvider.AddPlayer(6, "Tony", "Adams", PlayerPosition.Defender, 5)
        };
    }

    private void SetupTeams()
    {
        Teams.Add(MockTeamProvider.AddTeam(1, "Manchester United", SetupManUnitedPlayers()));
        Teams.Add(MockTeamProvider.AddTeam(2, "Arsenal", SetupArsenalPlayers()));
    }
}