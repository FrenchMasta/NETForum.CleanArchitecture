using Application.DTOs;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Queries.Player.GetPlayers;

public record GetPlayersQuery : IRequest<List<PlayerDto>>;

public class GetPlayersQueryHandler : IRequestHandler<GetPlayersQuery, List<PlayerDto>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public GetPlayersQueryHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<List<PlayerDto>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        var players = _playerRepository.GetAll();
        return _mapper.Map<List<PlayerDto>>(players);
    }
}