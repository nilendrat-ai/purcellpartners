namespace PurcepellPartners.ApiService.Services
{
    public interface IMissingNumberSearchService
    {
        /// <summary>
        /// Finds the missing number in a sequence of integers from 1 to n.
        /// </summary>
        /// <param name="inputNumbers"></param>
        /// <returns></returns>
        int FindMissingNumber(int[] inputNumbers);

        /// <summary>
        /// Finds all missing numbers in a sequence of integers from 1 to n.
        /// </summary>
        /// <param name="inputNumbers"></param>
        /// <returns></returns>
        List<int> FindMissingNumbers(int[] inputNumbers);
    }
}
