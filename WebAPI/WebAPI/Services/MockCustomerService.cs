using WebAPI.Models;

namespace WebAPI.Services
{
    public class MockCustomerService : ICustomerService
    {
        private static List<Customer> _customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Customer 1" },
            new Customer { Id = 2, Name = "Customer 2" },
            // Add more mock customers as needed
        };

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }

        public Customer GetCustomer(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            customer.Id = _customers.Count + 1;
            _customers.Add(customer);
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
            }
        }

        public void DeleteCustomer(int id)
        {
            var customerToDelete = _customers.FirstOrDefault(c => c.Id == id);
            if (customerToDelete != null)
            {
                _customers.Remove(customerToDelete);
            }
        }
    }
}
