using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.SacrificesToDemoGods.MockDatabase;

namespace Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly MockDatabase _mockDatabase;
    //private readonly MockDatabase _mockDatabase = new();

    // Showing the mock 'Dependency injection'. You could simplify by using above commented out code
    public PlayerRepository()
    {
        _mockDatabase = new MockDatabase();
    }

    public List<Player> GetAll()
    {
        return _mockDatabase.Players.ToList();
    }

    public List<Player> GetByTeamName(string teamName)
    {
        return _mockDatabase.Teams
            .Where(team => team.Name.Contains(teamName, StringComparison.InvariantCultureIgnoreCase))
            .SelectMany(team => team.Players)
            .ToList();
    }

    public Player? GetById(long id)
    {
        return _mockDatabase.Players.Find(player => player.Id == id);
    }
}