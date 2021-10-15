using GestioneOrdini.Core.Entity;
using GestioneOrdini.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneOrdini.EFCore.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly OrderContext ctx;

        public EFOrderRepository() : this(new OrderContext())
        {

        }

        public EFOrderRepository(OrderContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Order item)
        {
            try
            {
                if (item.Customer != null && item.Customer.Id > 0)
                {
                    var customerFound = ctx.Customers.Find(item.Customer.Id);
                    if (customerFound != null)
                        item.Customer = customerFound;
                }

                ctx.Orders.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Order item)
        {
            try
            {
                var book = ctx.Orders.Find(item.Id);

                if (book != null)
                    ctx.Orders.Remove(book);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Order> FetchAll()
        {
            try
            {
                return ctx.Orders.Include(o => o.Customer).ToList();
            }
            catch (Exception ex)
            {
                return new List<Order>();
            }
        }

        public Order GetById(int id)
        {
            try
            {
                return ctx.Orders.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Order item)
        {
            try
            {
                ctx.Orders.Update(item);
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
