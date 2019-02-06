using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMvc.Services
{
    public class RegistroDeVendasService
    {

        private readonly VendasWebMvcContext _context;

        public RegistroDeVendasService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeVendas>> FindByDateAsync(DateTime? inicial, DateTime? final)
        {
            var result = from obj in _context.registroDeVendas select obj;
            if (inicial.HasValue)
            {
                result = result.Where(x => x.Data >= inicial.Value);
            }

            if (final.HasValue)
            {
                result = result.Where(x => x.Data <= final.Value);
            }


            return await result
                .Include(x => x.vendedor)
                .Include(x => x.vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }
    }
}




