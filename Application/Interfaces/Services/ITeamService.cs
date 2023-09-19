using Application.DTOs;

namespace Application.Interfaces.Services;

public interface ITeamService
{
    List<TeamDto> GetAllTeams();
    TeamDto? GetByTeamName(string teamName);
    TeamDto? GetByTeamId(long id);
}