
using API.Controllers;
using Application.Commands.Team.TransferPlayerToTeam;
using Application.Exceptions;
using Application.ServiceResults;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace API.Tests.Controllers;

public class NewTeamsController_TransferPlayer_Should
{
    [Fact]
    public async Task ReturnNotFoundWhenNotFoundExceptionThrown()
    {

        // arrange
        var fakeMediator = A.Fake<ISender>();
        A.CallTo(() => fakeMediator
                .Send(A<TransferPlayerToTeamCommand>._, CancellationToken.None)
            )
            .Throws<NotFoundException>();

        var controller = new NewTeamsController(fakeMediator);

        // act
        var sut = await controller.TransferPlayer(0, 0);

        // assert
        Assert.IsType<NotFoundResult>(sut);
        
    }

    [Fact]
    public async Task ReturnNoContentWhenSuccessful()
    {

        // arrange
        var fakeMediator = A.Fake<ISender>();
        A.CallTo(() => fakeMediator
                .Send(A<TransferPlayerToTeamCommand>._, CancellationToken.None)
            )
            .Returns(new Updated());

        var controller = new NewTeamsController(fakeMediator);

        // act
        var sut = await controller.TransferPlayer(0, 0);

        // assert
        Assert.IsType<NoContentResult>(sut);
    }
}