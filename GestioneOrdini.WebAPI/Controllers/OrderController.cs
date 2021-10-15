using GestioneOrdini.Core.Entity;
using GestioneOrdini.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestioneOrdini.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL mainBusinessLayer;

        public OrderController(IOrderBL mainBusinessLayer)
        {
            this.mainBusinessLayer = mainBusinessLayer;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult GetOrders()
        {
            var result = mainBusinessLayer.FetchOrders();
            return Ok(result.ToList());
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult GetOrderBy(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var result = mainBusinessLayer
                .FetchOrders(o => o.Id == id)
                .FirstOrDefault();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult PostOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Invalid Order");

            var result = mainBusinessLayer
                .CreateOrder(order);

            if (!result)
                return BadRequest();

            return CreatedAtAction(
                "GetOrderBy",
                new { id = order.Id },
                order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order order)
        {
            if (order == null || id != order.Id)
                return BadRequest("Invalid Order");

            var result = mainBusinessLayer
                .EditOrder(order);

            if (!result)
                return BadRequest();

            return Ok(order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var order = mainBusinessLayer
                .FetchOrders(o => o.Id == id)
                .FirstOrDefault();

            if (order == null)
                return NotFound("Order cannot be found");

            var result = mainBusinessLayer
                .DeleteOrder(order);

            if (!result)
                return BadRequest();

            return Ok();
        }

        #region Pragmatic REST

        [HttpGet("year")]
        public ActionResult GetOrderPerYear()
        {
            var result = mainBusinessLayer
                .FetchOrders()
                .GroupBy(
                    o => o.DataOrdine.Year,
                    (key, grp) => new {
                        Year = key,
                        NumberOfOrders = grp.Count(),
                        TotalAmount = grp.Sum(o => o.Importo)
                    }
                 );

            return Ok(result);
        }

        [HttpGet("customer/{customerId}")]
        public ActionResult GetOrdersPerCustomer(int customerId)
        {
            if (customerId <= 0)
                return BadRequest("Invalid Customer Id");

            var result = mainBusinessLayer
                .FetchOrders(o => o.Customer.Id == customerId);

            return Ok(result);
        }

        #endregion
    }
}
