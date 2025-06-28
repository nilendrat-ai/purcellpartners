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

            //Check for duplicates
            if (input.Distinct().Count() != input.Length)
            {
                _logger.LogWarning("Input contains duplicate values.");
                throw new ArgumentException("Input array must contain distinct values.");
            }
        }
    }
}
