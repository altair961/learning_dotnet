namespace Commerce.Engine.Contracts
{
    public interface IProcessCreditCard
    {
        bool ProcessCreditCard(string customerName, string creditCard, string expirationDate, double amount);
    }
}
