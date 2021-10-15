using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GestioneOrdini.Core.Entity
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CodiceCliente { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Cognome { get; set; }

        public List<Order> Ordini { get; set; }
    }
}
