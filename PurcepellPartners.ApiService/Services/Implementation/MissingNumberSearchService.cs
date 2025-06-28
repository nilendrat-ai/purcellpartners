
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

        public int FindMissingNumber(int[] inputNumbers)
        {
            int result = -1;
            try
            {
                _inputValidator.Validate(inputNumbers);

                int counter = 0;

                inputNumbers = inputNumbers.OrderBy(x => x).ToArray();

                while (counter < inputNumbers.Length)
                {
                    if (inputNumbers[counter+1] - inputNumbers[counter] !=1)
                    {
                        result =  inputNumbers[counter]+1;
                        counter = inputNumbers.Length;
                    }
                    counter++;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in FindMissing Number : {ex.StackTrace}");
                throw;
            }

            return result;
        }

        public List<int> FindMissingNumbers(int[] inputNumbers)
        {
            throw new NotImplementedException();
        }
    }
}
