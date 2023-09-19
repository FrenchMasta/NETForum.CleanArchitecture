using Application.DTOs;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Queries.Player.GetPlayerDtoByName;

public record GetPlayerDtoByIdQuery : IRequest<PlayerDto>
{
    public long Id { get; set; }
}

public class GetPlayerDtoByIdQueryHandler : IRequestHandler<GetPlayerDtoByIdQuery, PlayerDto>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public GetPlayerDtoByIdQueryHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<PlayerDto> Handle(GetPlayerDtoByIdQuery request, CancellationToken cancellationToken)
    {
        var player = _playerRepository.GetById(request.Id);
        return _mapper.Map<PlayerDto>(player);
    }
}