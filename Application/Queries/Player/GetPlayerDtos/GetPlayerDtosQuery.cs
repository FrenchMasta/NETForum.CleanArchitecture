using Application.DTOs;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Queries.Player.GetPlayerDtos;

public record GetPlayerDtosQuery : IRequest<List<PlayerDto>>;

public class GetPlayerDtosQueryHandler : IRequestHandler<GetPlayerDtosQuery, List<PlayerDto>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public GetPlayerDtosQueryHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<List<PlayerDto>> Handle(GetPlayerDtosQuery request, CancellationToken cancellationToken)
    {
        var players = _playerRepository.GetAll();
        return _mapper.Map<List<PlayerDto>>(players);
    }
}