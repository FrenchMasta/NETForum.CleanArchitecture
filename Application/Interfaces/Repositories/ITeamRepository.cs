using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface ITeamRepository
{
    List<Team> GetAll();
    Team? GetByTeamName(string teamName);
    Team? GetById(long id); 
    void SaveChanges();
}