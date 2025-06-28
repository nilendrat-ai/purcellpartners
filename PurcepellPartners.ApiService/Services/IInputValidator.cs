namespace PurcepellPartners.ApiService.Services
{
    public interface IInputValidator
    {
        /// <summary>
        /// Validates the input array to ensure it is not null or empty and no duplicates.
        /// </summary>
        /// <param name="input"></param>
        void Validate(int[] input);
    }
}
