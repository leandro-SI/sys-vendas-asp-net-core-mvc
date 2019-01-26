using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class SellerService
    {
        private readonly VendasWebMvcContext _context;

        public SellerService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> RetorneTodos()
        {
            return _context.Vendedor.ToList();
        }

        public void InserirVendedor(Vendedor obj)
        {
            obj.departamento = _context.Departamento.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
