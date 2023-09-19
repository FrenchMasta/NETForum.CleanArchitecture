using Application.DTOs;

namespace Application.Interfaces.Services;

public interface IPlayerService
{
    List<PlayerDto> GetAllPlayers();
    List<PlayerDto> GetAllPlayersForTeam(string teamName);
    PlayerDto? GetPlayerById(long id);
}