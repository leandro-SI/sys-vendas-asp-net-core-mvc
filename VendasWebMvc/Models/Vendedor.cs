using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departamento departamento { get; set; }
        public ICollection<RegistroDeVendas> registroVendas { get; set; } = new List<RegistroDeVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataDeNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataDeNascimento = dataDeNascimento;
            SalarioBase = salarioBase;
            this.departamento = departamento;
        }

        public void AdicionaVendas(RegistroDeVendas venda)
        {
            registroVendas.Add(venda);
        }

        public void Removervenda(RegistroDeVendas venda)
        {
            registroVendas.Remove(venda);
        }

        public double TotalDeVendas(DateTime inicial, DateTime final)
        {
            return registroVendas.Where(venda => venda.Data >= inicial && venda.Data <= final).Sum(venda => venda.Quantidade);
        }
    }
}
