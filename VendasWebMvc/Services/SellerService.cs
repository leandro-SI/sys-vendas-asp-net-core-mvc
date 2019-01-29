using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Services.Exceptions;

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
            _context.Add(obj);
            _context.SaveChanges();
        }


        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Vendedor obj)
        {
            if(!_context.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id Not Found"); 
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
