using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vendedor> vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AdicionarVendedor(Vendedor vendedor)
        {
            vendedores.Add(vendedor);
        }

        public double TotalVendasDepartamento(DateTime inicial, DateTime final)
        {
            return vendedores.Sum(venda => venda.TotalDeVendas(inicial, final));
        }
    }
}
