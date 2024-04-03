using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF8.Services;
using ServiceReferenceEscenas;

namespace MvcCoreClienteWCF8.Controllers
{
    public class EscenasController : Controller
    {
        public ServiceEscenas service;

        public EscenasController(ServiceEscenas service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            EscenaPelicula[] escenas = await this.service.GetEscenasAsync();
            return View(escenas);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int idpelicula)
        {
            EscenaPelicula[] escenas = await this.service.GetEscenasPeliculaAsync(idpelicula);
            return View(escenas);
        }
    }
}
