using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Infrastructure.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public List<TeamDto> GetAllTeams()
    {
        var teams = _teamRepository.GetAll();
        return MapToTeamDtoCollection(teams);
    }

    public TeamDto? GetByTeamName(string teamName)
    {
        var team = _teamRepository.GetByTeamName(teamName);
        return team == null ? null : MapToTeamDto(team);
    }

    public TeamDto? GetByTeamId(long id)
    {
        var team = _teamRepository.GetById(id);
        return team == null ? null : MapToTeamDto(team);
    }

    #region Private Methods - Mapping

    private static List<TeamDto> MapToTeamDtoCollection(IEnumerable<Team> teams)
    {
        return teams.Select(MapToTeamDto).ToList();
    }

    private static TeamDto MapToTeamDto(Team team)
    {
        var mappedPlayers = MapToPlayerDtoCollection(team.Players);
        return new TeamDto(team.Id, team.Name, mappedPlayers);
    }

    private static List<PlayerDto> MapToPlayerDtoCollection(IEnumerable<Player> players)
    {
        return players.Select(MapToPlayerDto).ToList();
    }

    private static PlayerDto MapToPlayerDto(Player player)
    {
        return new PlayerDto(player.Id, player.FirstName, player.LastName, player.PlayerPosition, player.ShirtNumber);
    }

    #endregion
}