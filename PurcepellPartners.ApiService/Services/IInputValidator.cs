namespace PurcepellPartners.ApiService.Services
{
    public interface IInputValidator
    {
        /// <summary>
        /// Validates the input array to ensure it is not null or empty,must contains at least 2 different numbers.
        /// </summary>
        /// <param name="input"></param>
        void Validate(int[] input);
    }
}
