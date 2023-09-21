using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.ServiceResults;
using AutoMapper;
using MediatR;

namespace Application.Commands.Player;

public record AddPlayerCommand(PlayerDto PlayerDto): IRequest<Created>;

public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, Created>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public AddPlayerCommandHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<Created> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
    {
        var player = PopulatePlayerToBeAdded(request);

        var result = _playerRepository.CreatePlayer(player);

        return new Created(result);
    }

    private Domain.Models.Player PopulatePlayerToBeAdded(AddPlayerCommand request)
    {
        return _mapper.Map<Domain.Models.Player>(request.PlayerDto);
    }
}