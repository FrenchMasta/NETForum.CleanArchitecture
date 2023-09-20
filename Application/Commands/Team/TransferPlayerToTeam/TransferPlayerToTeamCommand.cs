using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.ServiceResults;
using MediatR;

namespace Application.Commands.Team.TransferPlayerToTeam
{
    public record TransferPlayerToTeamCommand(long playerId, long teamId) : IRequest<Updated>;

    public class TransferPlayerToTeamCommandHandler : IRequestHandler<TransferPlayerToTeamCommand, Updated>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;

        public TransferPlayerToTeamCommandHandler(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }

        public async Task<Updated> Handle(TransferPlayerToTeamCommand request, CancellationToken cancellationToken)
        {
            var player = _playerRepository.GetById(request.playerId);
            if (player is null)
            {
                throw new NotFoundException();
            }

            var teams = _teamRepository.GetAll();
            var newTeam = teams.FirstOrDefault(team => team.Id.Equals(request.teamId));
            var oldTeam = teams.FirstOrDefault(team=>team.Players.Contains(player));

            if (newTeam is null)
            {
                throw new NotFoundException();
            }

            oldTeam?.Players.Remove(player);

            newTeam.Players.Add(player);

            _teamRepository.SaveChanges();

            return new Updated();
        }
    }
}
