using BalanceApi.Logic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BalanceApi.Controllers
{
    /// <summary>
    /// Controller for GetBalance
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BalanceController : ControllerBase
    {
        private const string ExternalServiceBaseUrl = "https://bankingapi/";
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }
        /// <summary>
        /// Get Balance
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<decimal> GetBalance()
        {
            try
            {
                decimal balance = FetchBalanceFromDataSource();
                //decimal balance = FetchBalanceFromExternalService();
                return Ok(balance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

      

       
        private decimal FetchBalanceFromDataSource()
        {
            return _balanceService.GetBalance(); 
        }
        private async Task<decimal> FetchBalanceFromExternalService()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ExternalServiceBaseUrl + "balance");

                if (response.IsSuccessStatusCode)
                {
                    string balanceString = await response.Content.ReadAsStringAsync();
                    if (decimal.TryParse(balanceString, out decimal balance))
                    {
                        return balance;
                    }
                    else
                    {
                        throw new Exception("Unable to parse balance from the server response.");
                    }
                }
                else
                {
                    throw new Exception($"Failed to fetch user balance from the server. Status code: {response.StatusCode}");
                }
            }
        }
       

      
    }
}