using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services;
using VendasWebMvc.Services.Exceptions;

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
            if (!ModelState.IsValid)
            {
                var departamento = _departmentService.RetornarDepartamentos();
                var viewModel = new SellerFormViewModel { Vendedor = vendedor, Departamentos = departamento };
                return View(viewModel);
            }

            _sellerService.InserirVendedor(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Provided" });
            }

            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Provided" });
            }

            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Provided" });
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Found" });
            }

            List<Departamento> departamentos = _departmentService.RetornarDepartamentos();
            SellerFormViewModel viewModel = new SellerFormViewModel { Vendedor = obj, Departamentos = departamentos };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {

            if (!ModelState.IsValid)
            {
                var departamento = _departmentService.RetornarDepartamentos();
                var viewModel = new SellerFormViewModel { Vendedor = vendedor, Departamentos = departamento };
                return View(viewModel);
            }
            
            if(id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                _sellerService.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier

            };

                return View(viewModel);
        }

    }
}