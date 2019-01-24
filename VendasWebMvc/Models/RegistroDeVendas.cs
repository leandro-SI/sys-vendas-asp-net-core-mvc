using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantidade { get; set; }
        public SaleStatus Status { get; set; }
        public Vendedor vendedor { get; set; }

        public RegistroDeVendas()
        {
        }

        public RegistroDeVendas(int id, DateTime data, double quantidade, SaleStatus status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantidade = quantidade;
            Status = status;
            this.vendedor = vendedor;
        }
    }
}
