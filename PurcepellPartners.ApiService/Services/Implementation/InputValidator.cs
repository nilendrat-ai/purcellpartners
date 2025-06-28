namespace PurcepellPartners.ApiService.Services.Implementation
{
    public class InputValidator : IInputValidator
    {
        private readonly ILogger<InputValidator> _logger;
        public InputValidator(ILogger<InputValidator> logger)
        {
            _logger = logger;
        }
        public void Validate(int[] input)
        {

            //Check if the input array is null or empty
            if (input == null || input.Length == 0)
            {
                _logger.LogWarning("Input array is null or empty.");
                throw new ArgumentException("Input array cannot be null or empty.");
            }

            //Check if the input array has at least two elements
            if (input == null || input.Length < 2)
            {
                _logger.LogWarning("Input array is only contains one number.");
                throw new ArgumentException("Input array must contain at least two numbers to compare.");
            }

            //Check if the input array contains negative numbers
            if (input == null || input.Any(x => x < 0))
            {
                _logger.LogWarning("Input array contains negative.");
                throw new ArgumentException("Input array cannot contain negative values.");
            }

            //Check for duplicates
            if (input.Distinct().Count() != input.Length)
            {
                _logger.LogWarning("Input contains duplicate values.");
                throw new ArgumentException("Input array must not contain distinct values.");
            }
        }
    }
}
