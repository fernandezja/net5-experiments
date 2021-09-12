using _02_AspNetMvc.Business;
using _02_AspNetMvc.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_AspNetMvc.Controllers
{
    public class BancoController : Controller
    {
        private IBancoBusiness _bancoBusiness;

        public BancoController(IBancoBusiness bancoBusiness)
        {
            _bancoBusiness = bancoBusiness;
        }

        public IActionResult Index()
        {
            var bancos = _bancoBusiness.GetAll();
            return View(bancos);
        }

        public IActionResult Eliminar(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var banco = _bancoBusiness.Get(id);

            if (banco == null)
            {
                return NotFound();
            }

            return View(banco);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar([FromForm]Banco banco)
        {
            if (!ModelState.IsValid)
            {
                return View(banco);
            }

            var bancoToEliminate = _bancoBusiness.Get(banco.BancoId);

            if (bancoToEliminate==null)
            {
                return BadRequest();
            }

            var isDelete = _bancoBusiness.Delete(banco.BancoId);

            if (isDelete)
            {
                TempData["Mensaje"] = $"El Banco {bancoToEliminate.Nombre} se ha removido correctamente";
            }
            else
            {
                TempData["Mensaje"] = $"Se encotron un problema al eliminar el Banco {bancoToEliminate.Nombre}";
            }

            

            return RedirectToAction("Index");
        }
    }
}
