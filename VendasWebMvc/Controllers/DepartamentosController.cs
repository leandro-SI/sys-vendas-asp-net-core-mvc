using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {

            List<Departamento> list = new List<Departamento>();

            list.Add(new Departamento{ Id = 1, Name = "Eletrônicos"});
            list.Add(new Departamento{ Id = 2, Name = "Fashion"});
            list.Add(new Departamento { Id = 3, Name = "informatica" });


            return View(list);
        }
    }
}