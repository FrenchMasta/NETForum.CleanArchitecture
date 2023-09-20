using Domain.Models;

namespace Domain.Tests.Models
{
    public class Contract_IsValid_Should
    {
        [Fact]
        public void ReturnFalseIfSalaryNegative()
        {
            //arrange
            var fakeTeam = new Team();
            var mockContract = new Contract(fakeTeam, -1m, DateTime.MaxValue);
            // act
            var sut = mockContract.IsValid();
            // assert
            Assert.False(sut);
        }

        [Fact]
        public void ReturnTrueIfSalaryPositiveAndNotExpired()
        {
            //arrange
            var fakeTeam = new Team(); 
            var mockContract = new Contract(fakeTeam, 1m, DateTime.MaxValue);
            // act
            var sut = mockContract.IsValid();
            // assert
            Assert.True(sut);
        }

        [Fact]
        public void ReturnFalseIfSalaryZero()
        {
            //arrange
            var fakeTeam = new Team();
            var mockContract = new Contract(fakeTeam, 0m, DateTime.MaxValue);
            // act
            var sut = mockContract.IsValid();
            // assert
            Assert.False(sut);
        }

        [Fact]
        public void ReturnFalseIfExpired()
        {
            //arrange
            var fakeTeam = new Team();
            var mockContract = new Contract(fakeTeam, 1m, DateTime.MinValue);
            // act
            var sut = mockContract.IsValid();
            // assert
            Assert.False(sut);
        }
    }
}