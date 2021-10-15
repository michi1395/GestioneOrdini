using GestioneOrdini.Core.Entity;
using GestioneOrdini.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneOrdini.Core.BusinessLayer
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRepository orderRepo;
        private readonly ICustomerRepository customerRepo;

        public OrderBL(
            IOrderRepository orderRepo,
            ICustomerRepository customerRepo
        )
        {
            this.orderRepo = orderRepo;
            this.customerRepo = customerRepo;
        }


        public IEnumerable<Customer> FetchCustomers(Func<Customer, bool> filter = null)
        {
            var allData = customerRepo.FetchAll();

            if (filter != null)
                return allData.Where(filter);

            return allData;
        }

        public bool CreateCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                throw new ArgumentNullException("Customer is invalid");

            return customerRepo.Add(newCustomer);
        }
        public bool EditCustomer(Customer editedCustomer)
        {
            if (editedCustomer == null)
                throw new ArgumentNullException("Customer is invalid");

            return customerRepo.Update(editedCustomer);
        }

        public bool DeleteCustomer(Customer customerToBeDeleted)
        {
            if (customerToBeDeleted == null)
                throw new ArgumentNullException("Customer is invalid");

            return customerRepo.Delete(customerToBeDeleted);
        }

    
        public bool CreateOrder(Order newOrder)
        {
            if (newOrder == null)
                throw new ArgumentNullException("Order is invalid");

            return orderRepo.Add(newOrder);
        }

        public bool DeleteOrder(Order orderToBeDeleted)
        {
            if (orderToBeDeleted == null)
                throw new ArgumentNullException("Order is invalid");

            return orderRepo.Delete(orderToBeDeleted);
        }
        public bool EditOrder(Order editedOrder)
        {
            if (editedOrder == null)
                throw new ArgumentNullException("Order is invalid");

            return orderRepo.Update(editedOrder);
        }

        public IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null)
        {
            var allData = orderRepo.FetchAll();

            if (filter != null)
                return allData.Where(filter);

            return allData;
        }
    } 
}
