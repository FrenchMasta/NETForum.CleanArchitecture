
using API.Controllers;
using Application.Commands.Team.TransferPlayerToTeam;
using Application.Exceptions;
using Application.ServiceResults;
using FakeItEasy;
using MediatR;
using Xunit;

namespace API.Tests.Controllers
{
    public class TeamsController_TransferPlayer_Should
    {
        [Fact]
        public async Task ReturnNotFoundWhenNotFoundExceptionThrown()
        {

            // arrange
            var fakeMediator = A.Fake<ISender>();
            var fakeCommand = new TransferPlayerToTeamCommand(0,0);
            A.CallTo(() => fakeMediator
                .Send(A<TransferPlayerToTeamCommand>._, CancellationToken.None)
            )
            .Throws<NotFoundException>();

            var controller = new TeamsController(fakeMediator);

            // act
            var sut = ////////
            Assert.ThrowsAsync<NotFoundException>(()=>controller.TransferPlayer(0, 0));

            // assert
        }
    }
}
