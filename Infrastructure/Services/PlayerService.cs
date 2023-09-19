using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;

namespace Infrastructure.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public List<PlayerDto> GetAllPlayers()
    {
        var players = _playerRepository.GetAll();
        return _mapper.Map<List<PlayerDto>>(players);
    }

    public List<PlayerDto> GetAllPlayersForTeam(string teamName)
    {
        var players = _playerRepository.GetByTeamName(teamName);
        return _mapper.Map<List<PlayerDto>>(players);
    }

    public PlayerDto? GetPlayerById(long id)
    {
        var player = _playerRepository.GetById(id);
        return player == null ? null : _mapper.Map<PlayerDto>(player);
    }
}