using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using PairProgramming.Common.Integration.Dto.ApiToIntegration.Basket;
using PairProgramming.Integration.Data;
using PairProgramming.Integration.Orchestration;
using Xunit;

namespace PairProgramming.Integration.Tests
{
    public class BasketOrchestratorTests
    {
        private readonly Mock<IUserBasketDataProvider> userBasketDataProviderMock;
        private readonly IFixture fixture;
        private readonly BasketOrchestrator sut;

        public BasketOrchestratorTests()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
            userBasketDataProviderMock = fixture.Freeze<Mock<IUserBasketDataProvider>>();
            sut = fixture.Create<BasketOrchestrator>();
        }

        [Fact]
        public async Task ShouldGetUserBasket()
        {
            // arrange
            var userSessionId = fixture.Create<string>();
            var basketResult = fixture.Create<List<string>>();
            var getBasketRequest = fixture.Create<IntegrationGetUserBasketRequest>();
            getBasketRequest.SessionId = userSessionId;

            userBasketDataProviderMock.Setup(x => x.GetUserBasketData(userSessionId))
                .Returns(basketResult);

            // act
            var result = await sut.GetUserBasket(getBasketRequest);

            // assert
            userBasketDataProviderMock.Verify(x => x.GetUserBasketData(userSessionId), Times.Once);
            result.BasketItems.Should().BeEquivalentTo(basketResult);
        }
    }
}
