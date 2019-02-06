using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly RegistroDeVendasService _registroDeVendasService;

        public RegistroDeVendasController(RegistroDeVendasService registroDeVendasService)
        {
            _registroDeVendasService = registroDeVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> SimpleSearch(DateTime? inicial, DateTime? final)
        {
            if (!inicial.HasValue)
            {
                inicial = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!final.HasValue)
            {
                final = DateTime.Now;
            }

            ViewData["inicial"] = inicial.Value.ToString("yyyy-MM-dd");
            ViewData["final"] = final.Value.ToString("yyyy-MM-dd");
            var result = await _registroDeVendasService.FindByDateAsync(inicial, final);

            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? inicial, DateTime? final)
        {
            if (!inicial.HasValue)
            {
                inicial = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!final.HasValue)
            {
                final = DateTime.Now;
            }

            ViewData["inicial"] = inicial.Value.ToString("yyyy-MM-dd");
            ViewData["final"] = final.Value.ToString("yyyy-MM-dd");
            var result = await _registroDeVendasService.FindByDateGroupingAsync(inicial, final);

            return View(result);

        }
    }
}



