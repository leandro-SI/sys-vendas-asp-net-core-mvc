using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services;


namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;



        public VendedoresController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.RetorneTodos();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamento = _departmentService.RetornarDepartamentos();
            var viewModel = new SellerFormViewModel { Departamentos = departamento };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _sellerService.InserirVendedor(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}