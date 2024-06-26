﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF8.Services;
using ServiceReferenceCoches;

namespace MvcCoreClienteWCF8.Controllers
{
    public class CochesController : Controller
    {
        private ServiceCoches service;

        public CochesController(ServiceCoches service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            Coche[] coches = await this.service.GetCochesAsync();
            return View(coches);
        }

        public async Task<IActionResult> Details(int idcoche)
        {
            Coche coche = await this.service.FindCocheAsync(idcoche);
            return View(coche);
        }
    }
}
