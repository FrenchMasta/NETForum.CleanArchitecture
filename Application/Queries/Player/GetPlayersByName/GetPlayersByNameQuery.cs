using Application.DTOs;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Queries.Player.GetPlayersByName;

public record GetPlayersByNameQuery(string TeamName) : IRequest<List<PlayerDto>>;

public class GetPlayersByNameQueryHandler : IRequestHandler<GetPlayersByNameQuery, List<PlayerDto>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public GetPlayersByNameQueryHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<List<PlayerDto>> Handle(GetPlayersByNameQuery request, CancellationToken cancellationToken)
    {
        var player = _playerRepository.GetByTeamName(request.TeamName);
        return _mapper.Map<List<PlayerDto>>(player);
    }
}