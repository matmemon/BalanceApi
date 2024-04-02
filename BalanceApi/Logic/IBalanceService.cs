namespace BalanceApi.Logic
{
    /// <summary>
    /// Interface for Performing Operation GetBalance CreditBalance and DebitBalance
    /// </summary>
    public interface IBalanceService
    {
        decimal GetBalance();
        Task<decimal?> CreditBalance(decimal amount);
        Task<decimal?> DebitBalance(decimal amount);
    }
}
