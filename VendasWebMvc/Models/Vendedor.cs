using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho entre 3 e 60")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeNascimento { get; set; }

        [Display(Name = "Salário Base")]

        [Range(100.00, 5000.00, ErrorMessage = "Olha o range")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
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
            this.Departamento = departamento;
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
