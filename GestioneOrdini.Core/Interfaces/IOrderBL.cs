using GestioneOrdini.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.Core.Interfaces
{
    public interface IOrderBL
    {

        IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null);
        bool CreateOrder(Order newOrder);
        bool EditOrder(Order editedOrder);
        bool DeleteOrder(Order orderToBeDeleted);

      
        IEnumerable<Customer> FetchCustomers(Func<Customer, bool> filter = null);
        bool CreateCustomer(Customer newCustomer);
        bool EditCustomer(Customer editedCustomer);
        bool DeleteCustomer(Customer customerToBeDeleted);


    }
}
