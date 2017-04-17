using Commerce.Engine.Entities;
using System.Collections.Generic;

namespace Commerce.Engine.Contracts
{
    public interface IStoreRepository
    {
        List<Product> Products { get; }
        List<Inventory> ProductInventory { get; }
        List<Customer> Customers { get; }
        void Initialize();
        Customer GetCustomerByEmail(string email);
    }
}
