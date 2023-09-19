using Application.DTOs;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Queries.Player.GetPlayerDtoByName;

public record GetPlayerDtosByNameQuery : IRequest<List<PlayerDto>>
{
    public string TeamName { get; set; }
}

public class GetPlayerDtosByNameQueryHandler : IRequestHandler<GetPlayerDtosByNameQuery, List<PlayerDto>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public GetPlayerDtosByNameQueryHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<List<PlayerDto>> Handle(GetPlayerDtosByNameQuery request, CancellationToken cancellationToken)
    {
        var player = _playerRepository.GetByTeamName(request.TeamName);
        return _mapper.Map<List<PlayerDto>>(player);
    }
}