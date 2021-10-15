using GestioneOrdini.Core.Entity;
using GestioneOrdini.Core.Interfaces;
using GestioneOrdini.Core.BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using GestioneOrdini.EFCore.Repository;

namespace GestioneOrdini.WCF
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service1" nel codice e nel file di configurazione contemporaneamente.
    public class CustomerService : ICustomerService
    {
        private readonly IOrderBL mainBusinessLayer;

        public CustomerService()
        {
            mainBusinessLayer = new OrderBL(
                new EFOrderRepository(),
                new EFCustomerRepository()
            );
        }
        public bool AddCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return false;

            var result = mainBusinessLayer
                .CreateCustomer(newCustomer);

            return result;
        }

        public bool DeleteCustomerById(int id)
        {
            if (id <= 0)
                return false;

            var customerToBeDeleted = mainBusinessLayer
                .FetchCustomers(c => c.Id == id)
                .FirstOrDefault();

            if (customerToBeDeleted == null)
                return false;

            var result = mainBusinessLayer
                .DeleteCustomer(customerToBeDeleted);

            return result;
        }

        public List<Customer> GetAllCustomers()
        {
            var result = mainBusinessLayer.FetchCustomers().ToList();
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            if (id <= 0)
                return null;

            var customer = mainBusinessLayer
                .FetchCustomers(c => c.Id == id)
                .FirstOrDefault();

            return customer;
        }

        public bool UpdateCustomer(Customer updatedCustomer)
        {
            if (updatedCustomer == null)
                return false;

            var result = mainBusinessLayer
                .EditCustomer(updatedCustomer);

            return result;
        }
    }
}
