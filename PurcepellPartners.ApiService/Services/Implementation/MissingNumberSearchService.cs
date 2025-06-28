
namespace PurcepellPartners.ApiService.Services.Implementation
{
    public class MissingNumberSearchService : IMissingNumberSearchService
    {
        private readonly ILogger<MissingNumberSearchService> _logger;
        private readonly IInputValidator _inputValidator;

        public MissingNumberSearchService(ILogger<MissingNumberSearchService> logger, IInputValidator inputValidator)
        {
            _logger = logger;
            _inputValidator = inputValidator;
        }

        public List<int> FindMissingNumbers(int[] inputNumbers)
        {
            List<int> result = new List<int>();
            try
            {
                _inputValidator.Validate(inputNumbers);

                inputNumbers = inputNumbers.OrderBy(x => x).ToArray();

                for (int i = 0; i < inputNumbers.Length - 1; i++)
                {
                    int current = inputNumbers[i];
                    int next = inputNumbers[i + 1];

                    // If the difference is more than 1, find the missing numbers
                    if (next - current > 1)
                    {
                        for (int missing = current + 1; missing < next; missing++)
                        {
                            result.Add(missing);
                        }
                    }
                }

            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning($"Input validation failed: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in FindMissingNumbers Number : {ex.StackTrace}");
                throw;
            }

            return result;
        }
    }
}
