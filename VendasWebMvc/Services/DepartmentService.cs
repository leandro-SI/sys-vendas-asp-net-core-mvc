using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class DepartmentService
    {
        private readonly VendasWebMvcContext _context;

        public DepartmentService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> RetornarDepartamentos()
        {
            return _context.Departamento.OrderBy(x => x.Name).ToList();
        }
    }
}
