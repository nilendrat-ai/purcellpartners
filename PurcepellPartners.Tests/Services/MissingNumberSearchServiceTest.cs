using Microsoft.Extensions.Logging;
using Moq;
using PurcepellPartners.ApiService.Services;
using PurcepellPartners.ApiService.Services.Implementation;

namespace PurcepellPartners.Tests.Services
{
    public class MissingNumberSearchServiceTest
    {
        private readonly MissingNumberSearchService _service;

        public MissingNumberSearchServiceTest()
        {
            var loggerMock = new Mock<ILogger<MissingNumberSearchService>>();
            var validatorMock = new Mock<IInputValidator>();

            _service = new MissingNumberSearchService(loggerMock.Object, validatorMock.Object);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 3 }, new[] { 2 })]
        [InlineData(new[] { 0, 1, 3, 5 }, new[] { 2, 4 })]
        [InlineData(new[] { 0, 1, 3, 6, 7, 9 }, new[] { 2, 4, 5, 8 })]
        public void FindMissingNumbers_ValidInput_ReturnsMissingNumbers(int[] input, int[] expected)
        {
            var result = _service.FindMissingNumbers(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2 }, new int[]{ })]
        public void FindMissingNumbers_ValidInput_NoMissingNumbers(int[] input, int[] expected)
        {
            var result = _service.FindMissingNumbers(input);
            Assert.Equal(expected, result);
        }
    }
}
