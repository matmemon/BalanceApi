namespace BalanceApi.Logic
{
    /// <summary>
    /// Class to perform all operations
    /// </summary>
    public class BalanceService : IBalanceService
    {
        private static decimal DummyBalance = 6000.00m;
        /// <summary>
        /// Get Balance Operations
        /// </summary>
        /// <returns></returns>
        public decimal GetBalance()
        {
            return DummyBalance;
        }
        /// <summary>
        /// Credit Balance operations
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<decimal?> CreditBalance(decimal amount)
        {
            try
            {
                DummyBalance += amount;
                return await Task.FromResult(DummyBalance);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while crediting balance: {ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// Debit Balance Operations
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<decimal?> DebitBalance(decimal amount)
        {
            try
            {
                DummyBalance -= amount;
                return await Task.FromResult(DummyBalance);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while debiting balance: {ex.Message}");
                return null;
            }
        }
    }
}
