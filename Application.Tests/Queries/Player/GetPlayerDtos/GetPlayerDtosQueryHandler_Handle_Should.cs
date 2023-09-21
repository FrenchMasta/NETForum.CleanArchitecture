using Application.Interfaces.Repositories;
using Application.Queries.Player.GetPlayers;
using Application.Tests.Abstractions;
using Domain.Enums;
using FakeItEasy;

namespace Application.Tests.Queries.Player.GetPlayerDtos
{
    public class GetPlayerDtosQueryHandler_Handle_Should : HandlerTest
    {
        [Fact]
        public async Task ReturnPlayers()
        {
            // arrange
            var fakePlayerRepository = A.Fake<IPlayerRepository>();
            var fakePlayers = new List<Domain.Models.Player>
            {
                new()
                {
                    FirstName = "Lionel",
                    LastName = "Messi",
                    PlayerPosition = PlayerPosition.Forward,
                    ShirtNumber = 10,
                },
                new()
                {
                    FirstName = "Cristiano",
                    LastName = "Ronaldo",
                    PlayerPosition = PlayerPosition.Forward,
                    ShirtNumber = 7,
                }
            };

            A.CallTo(() => fakePlayerRepository.GetAll()).Returns(fakePlayers);

            var handler = new GetPlayersQueryHandler(fakePlayerRepository, Mapper);

            var fakeRequest = A.Fake<GetPlayersQuery>();

            var expectedPlayerDtoCount = 2;

            // act
            var sut = await handler.Handle(fakeRequest, CancellationToken.None);

            //assert
            A.CallTo(() => fakePlayerRepository.GetAll()).MustHaveHappened();

            Assert.Equal(expectedPlayerDtoCount, sut.Count);
        }

        [Fact]
        public async Task MapPlayerPositionToString()
        {
            // arrange
            var fakePlayerRepository = A.Fake<IPlayerRepository>();
            var fakePlayers = new List<Domain.Models.Player>
            {
                new()
                {
                    FirstName = "Lionel",
                    LastName = "Messi",
                    PlayerPosition = PlayerPosition.Forward,
                    ShirtNumber = 10,
                }
            };

            A.CallTo(() => fakePlayerRepository.GetAll()).Returns(fakePlayers);

            var handler = new GetPlayersQueryHandler(fakePlayerRepository, Mapper);

            var fakeRequest = A.Fake<GetPlayersQuery>();

            // act
            var sut = await handler.Handle(fakeRequest, CancellationToken.None);

            //assert
            A.CallTo(() => fakePlayerRepository.GetAll()).MustHaveHappened();
            Assert.Equal("Forward", sut[0].PlayerPosition);
        }
    }
}
