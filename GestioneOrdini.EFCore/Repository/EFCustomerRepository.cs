using GestioneOrdini.Core.Entity;
using GestioneOrdini.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneOrdini.EFCore.Repository
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly OrderContext ctx;

        public EFCustomerRepository() : this(new OrderContext())
        {

        }

        public EFCustomerRepository(OrderContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Customer item)
        {
            try
            {
                ctx.Customers.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Customer item)
        {
            try
            {
                var book = ctx.Customers.Find(item.Id);

                if (book != null)
                    ctx.Customers.Remove(book);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Customer> FetchAll()
        {
            try
            {
                return ctx.Customers.Include(o => o.Ordini).ToList();
            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }
        }

        public Customer GetById(int id)
        {
            try
            {
                return ctx.Customers.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Customer item)
        {
            try
            {
                ctx.Customers.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
