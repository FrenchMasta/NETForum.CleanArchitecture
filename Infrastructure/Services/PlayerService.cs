using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Infrastructure.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public List<PlayerDto> GetAllPlayers()
    {
        var players = _playerRepository.GetAll();
        return MapToPlayerDtoCollection(players);
    }

    public List<PlayerDto> GetAllPlayersForTeam(string teamName)
    {
        var players = _playerRepository.GetByTeamName(teamName);
        return MapToPlayerDtoCollection(players);
    }

    public PlayerDto? GetPlayerById(long id)
    {
        var player = _playerRepository.GetById(id);
        return player == null ? null : MapToPlayerDto(player);
    }

    private static List<PlayerDto> MapToPlayerDtoCollection(IEnumerable<Player> players)
    {
        return players.Select(MapToPlayerDto).ToList();
    }

    private static PlayerDto MapToPlayerDto(Player player)
    {
        return new PlayerDto(player.Id, player.FirstName, player.LastName, player.PlayerPosition, player.ShirtNumber);
    }
}