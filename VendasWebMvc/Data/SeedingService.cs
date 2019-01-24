using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Data
{
    public class SeedingService
    {
        private VendasWebMvcContext _context;

        public SeedingService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Departamento.Any() || 
                _context.Vendedor.Any() ||
                _context.registroDeVendas.Any())
            {
                return; // O banco de dados já foi populado
            }

            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletronicos");
            Departamento d3 = new Departamento(3, "Moda");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Boby brow", "boby@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor v2 = new Vendedor(2, "Maria elisa", "maria@gmail.com", new DateTime(1998, 4, 21), 1000.0, d2);
            Vendedor v3 = new Vendedor(3, "Joana Dark", "joana@gmail.com", new DateTime(1998, 4, 21), 1000.0, d3);
            Vendedor v4 = new Vendedor(4, "Messias Bolsonaro", "bolsonaro@gmail.com", new DateTime(1998, 4, 21), 1000.0, d4);

            RegistroDeVendas r1 = new RegistroDeVendas(1, new DateTime(2018, 9, 25), 11000.00, SaleStatus.Faturado, v1);
            RegistroDeVendas r2 = new RegistroDeVendas(2, new DateTime(2018, 9, 25), 11000.00, SaleStatus.Faturado, v2);
            RegistroDeVendas r3 = new RegistroDeVendas(3, new DateTime(2018, 9, 25), 11000.00, SaleStatus.Faturado, v1);
            RegistroDeVendas r4 = new RegistroDeVendas(4, new DateTime(2018, 9, 25), 11000.00, SaleStatus.Faturado, v2);

            _context.Departamento.AddRange(d1, d2, d3, d4);
            _context.Vendedor.AddRange(v1, v2, v3, v4);
            _context.registroDeVendas.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();
        }
    }
}
