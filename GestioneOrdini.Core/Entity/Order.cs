using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DataOrdine { get; set; }
        public string CodiceOrdine { get; set; }
        public string CodiceProdotto { get; set; }
        public decimal Importo { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
