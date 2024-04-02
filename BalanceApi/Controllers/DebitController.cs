using BalanceApi.Logic;
using Microsoft.AspNetCore.Mvc;

namespace BalanceApi.Controllers
{
    /// <summary>
    /// Controller Debit
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DebitController : Controller
    {
        private readonly IBalanceService _balanceService;

        public DebitController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

       
        /// <summary>
        /// Operation for Debit
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<decimal>> DebitBalance([FromBody] decimal amount)
        {
            try
            {
                decimal? newBalance = await _balanceService.DebitBalance(amount);

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
