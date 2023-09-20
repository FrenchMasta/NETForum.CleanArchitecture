using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IPlayerRepository
{
    List<Player> GetAll();
    List<Player> GetByTeamName(string teamName);
    Player? GetById(long id);
    void SaveChanges();
}