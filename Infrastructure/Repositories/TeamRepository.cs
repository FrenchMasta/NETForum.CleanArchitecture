using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.SacrificesToDemoGods.MockDatabase;

namespace Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly MockDatabase _mockDatabase;
    //private readonly MockDatabase _mockDatabase = new();

    // Showing the mock 'Dependency injection'. You could simplify by using above commented out code
    public TeamRepository()
    {
        _mockDatabase = new MockDatabase();
    }

    public List<Team> GetAll()
    {
        return _mockDatabase.Teams.ToList();
    }

    public Team? GetByTeamName(string teamName)
    {
        return _mockDatabase.Teams
            .Find(team => team.Name.Contains(teamName, StringComparison.InvariantCultureIgnoreCase));
    }

    public Team? GetById(long id)
    {
        return _mockDatabase.Teams.Find(player => player.Id == id);
    }

    public void SaveChanges()
    {
        _mockDatabase.SaveChanges();
    }
}