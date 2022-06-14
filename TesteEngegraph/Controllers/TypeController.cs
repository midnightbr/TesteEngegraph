using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteEngegraph.Models;
using TesteEngegraph.Services;

namespace TesteEngegraph.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _tipoRepositorio;

        public TypeController(ITypeService tipoRepositorio)
        {
            _tipoRepositorio = tipoRepositorio;
        }

        public IActionResult Index()
        {
            List<Types> types = _tipoRepositorio.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Types type)
        {
            _tipoRepositorio.Insert(type);
            return RedirectToRoute(new { controller = "Contact", action = "Index"});
        }
    }
}
