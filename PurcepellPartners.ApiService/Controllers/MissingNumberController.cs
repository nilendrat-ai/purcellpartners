using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurcepellPartners.ApiService.Services;

namespace PurcepellPartners.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissingNumberController : ControllerBase
    {
        private readonly IMissingNumberSearchService _missingNumberService;

        public MissingNumberController(IMissingNumberSearchService missingNumberService)
        {
            _missingNumberService = missingNumberService;
        }

        /// <summary>
        /// Finds the missing number in the input array.
        /// </summary>
        /// <param name="numbers">Array of distinct numbers in range 0 to n with one missing.</param>
        /// <returns>The missing number.</returns>
        [HttpPost]
        public ActionResult<int> Post([FromBody] int[] numbers)
        {
            try
            {
                List<int> missing = _missingNumberService.FindMissingNumbers(numbers);
                return Ok(missing);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
