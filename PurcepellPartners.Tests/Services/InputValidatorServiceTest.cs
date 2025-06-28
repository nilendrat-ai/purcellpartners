using Microsoft.Extensions.Logging;
using PurcepellPartners.ApiService.Services;
using PurcepellPartners.ApiService.Services.Implementation;
using Moq;

namespace PurcepellPartners.Tests.Services
{
    public class InputValidatorServiceTest
    {
        private readonly IInputValidator _inputValidator;

        public InputValidatorServiceTest()
        {
            var mockObj = new Mock<ILogger<InputValidator>>();
            _inputValidator = new InputValidator(mockObj.Object);
        }

        [Fact]
        public void Validate_ValidInput()
        {
            int[] input = { 1, 2, 3, 4 };
            Exception expected = Record.Exception(() => _inputValidator.Validate(input));
            Assert.Null(expected);
        }

        [Fact]
        public void Validate_InvalidInput_Null()
        {
            ArgumentException expected = Assert.Throws<ArgumentException>(() => _inputValidator.Validate(null));
            Assert.Throws<ArgumentException>(() => _inputValidator.Validate(null));
            Assert.Equal("Input array cannot be null or empty.", expected.Message);
        }

        [Fact]
        public void Validate_InvalidInput_EmptyArray()
        {
            int[] input = { };
            ArgumentException expected = Assert.Throws<ArgumentException>(() => _inputValidator.Validate(input));
            Assert.Equal("Input array cannot be null or empty.", expected.Message);
        }

        [Fact]
        public void Validate_InvalidInput_DuplicatesArray()
        {
            int[] input = { 1,2,1 };
            ArgumentException expected = Assert.Throws<ArgumentException>(() => _inputValidator.Validate(input));
            Assert.Equal("Input array must not contain distinct values.", expected.Message);
        }

        [Fact]
        public void Validate_InvalidInput_NegativeArray()
        {
            int[] input = { 1, -2 };
            ArgumentException expected = Assert.Throws<ArgumentException>(() => _inputValidator.Validate(input));
            Assert.Equal("Input array cannot contain negative values.", expected.Message);
        }

        [Fact]
        public void Validate_InvalidInput_SingleItemArray()
        {
            int[] input = { 1 };
            ArgumentException expected = Assert.Throws<ArgumentException>(() => _inputValidator.Validate(input));
            Assert.Equal("Input array must contain at least two numbers to compare.", expected.Message);
        }
    }
}
