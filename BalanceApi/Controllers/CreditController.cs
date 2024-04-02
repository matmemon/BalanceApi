using BalanceApi.Logic;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApi.Controllers
{
    /// <summary>
    /// Controller for credit
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CreditController : Controller
    {
        private readonly IBalanceService _balanceService;

        public CreditController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }
        /// <summary>
        /// Operation for credit balance
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<decimal>> CreditBalance([FromBody] decimal amount)
        {
            try
            {
                // Call the CreditBalance method of _balanceService
                decimal? newBalance = await _balanceService.CreditBalance(amount);

                // If the operation is successful, return the updated balance
                return Ok(newBalance);
            }
            catch (Exception ex)
            {
                // If an error occurs, return an internal server error with the error message
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
