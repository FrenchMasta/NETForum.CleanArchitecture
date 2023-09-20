using Application.Commands.Team.TransferPlayerToTeam;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.ServiceResults;
using Application.Tests.Abstractions;
using Domain.Enums;
using Domain.Models;
using FakeItEasy;

namespace Application.Tests.Commands.Team.TransferPlayerToTeam
{
    public class TransferPlayerToTeamCommandHandler_Handle_Should : HandlerTest
    {
        [Fact]
        public async Task ThrowNotFoundWhenPlayerNotFound()
        {
            var fakePlayerRepository = A.Fake<IPlayerRepository>();
            var fakeTeamRepository = A.Fake<ITeamRepository>();

            A.CallTo(() => fakePlayerRepository.GetById(A<long>._))
                .Returns(null);

            var handler = new TransferPlayerToTeamCommandHandler(fakePlayerRepository, fakeTeamRepository);

            var fakeRequest = new TransferPlayerToTeamCommand(
                2,
                1);


            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(fakeRequest, CancellationToken.None));

            A.CallTo(() => fakePlayerRepository.GetById(A<long>._)).MustHaveHappened();
            A.CallTo(() => fakeTeamRepository.GetAll()).MustNotHaveHappened();
        }

        [Fact]
        public async Task ThrowNotFoundWhenNewTeamNotFound()
        {
            var fakePlayerRepository = A.Fake<IPlayerRepository>();
            var fakeTeamRepository = A.Fake<ITeamRepository>();

            A.CallTo(() => fakePlayerRepository.GetById(A<long>._))
                .Returns(new Player());

            A.CallTo(() => fakeTeamRepository.GetAll())
                .Returns(new List<Domain.Models.Team>());

            var handler = new TransferPlayerToTeamCommandHandler(fakePlayerRepository, fakeTeamRepository);

            var fakeRequest = new TransferPlayerToTeamCommand(
                2,
                1);


            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(fakeRequest, CancellationToken.None));



            A.CallTo(() => fakePlayerRepository.GetById(A<long>._)).MustHaveHappened();
            A.CallTo(() => fakeTeamRepository.GetAll()).MustHaveHappened();

        }

        [Fact]
        public async Task ReturnUpdatedWhenTransferSuccessful()
        {
            var fakePlayerRepository = A.Fake<IPlayerRepository>();
            var fakeTeamRepository = A.Fake<ITeamRepository>();

            var fakePlayer = new Player
            {
                Id = 2,
                ShirtNumber = 7,
                PlayerPosition = PlayerPosition.Forward,
                FirstName = "Mason",
                LastName = "Mount"
            };

            var fakeOldTeam = new Domain.Models.Team
            {
                Id = 13,
                Name = "Chelsea",
                Players = new()
                {
                    fakePlayer
                }
            };

            var fakeNewTeam = new Domain.Models.Team
            {
                Id = 1,
                Name = "Manchester United",
                Players = new()
            };

            var fakeTeams = new List<Domain.Models.Team>
            {
                fakeOldTeam, fakeNewTeam
            };

            A.CallTo(() => fakePlayerRepository.GetById(A<long>._))
                .Returns(fakePlayer);

            A.CallTo(() => fakeTeamRepository.GetAll())
                .Returns(fakeTeams);

            var handler = new TransferPlayerToTeamCommandHandler(fakePlayerRepository, fakeTeamRepository);

            var fakeRequest = new TransferPlayerToTeamCommand(
                2,
               1);

            var sut = await handler.Handle(fakeRequest, CancellationToken.None);

            A.CallTo(() => fakeTeamRepository.SaveChanges()).MustHaveHappened();
            Assert.IsType<Updated>(sut);
            Assert.DoesNotContain(fakePlayer, fakeOldTeam.Players);
            Assert.Contains(fakePlayer, fakeNewTeam.Players);
        }
    }
}
