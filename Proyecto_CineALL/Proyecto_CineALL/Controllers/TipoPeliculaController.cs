using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_CineALL.ServiceReference1;
namespace Proyecto_CineALL.Controllers
{
    public class TipoPeliculaController : Controller
    {
        Service1Client servicio = new Service1Client();
        public ActionResult TipoPelicula()
        {
            return View(servicio.listTipoPelicula());
        }


        public ActionResult Create()
        {
            return View(new TipoPelicula());
        }
        [HttpPost]
        public ActionResult Create(TipoPelicula reg)
        {

            ViewBag.mensaje = servicio.addTipoPelicula(reg);
            return View(reg);
        }


        public ActionResult Edit(int codigo = 0)
        {
            if (codigo == 0) return RedirectToAction("TipoPelicula");
            TipoPelicula reg = servicio.listTipoPelicula().Where(x => x.codigo == codigo).FirstOrDefault();
            return View(reg);
        }
        [HttpPost]
        public ActionResult Edit(TipoPelicula reg)
        {
            ViewBag.mensaje = servicio.updateTipoPelicula(reg);
            return View(reg);
        }


        public ActionResult Delete(TipoPelicula reg)
        {
            TempData["mensaje"] = servicio.deleteTipoPelicula(reg);
            return RedirectToAction("TipoPelicula");
        }
    }
}