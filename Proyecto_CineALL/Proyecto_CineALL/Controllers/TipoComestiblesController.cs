using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Proyecto_CineALL.ServiceReference1;
namespace Proyecto_CineALL.Controllers
{
    public class TipoComestiblesController : Controller
    {
        Service1Client servicio = new Service1Client();
        public ActionResult TipoComestibles()
        {
            return View(servicio.tipocomestibles());
        }

        public ActionResult Create()
        {
            return View(new TipoComestible());
        }
        [HttpPost]
        public ActionResult Create(TipoComestible reg)
        {
            ViewBag.mensaje = servicio.AgregarTipCome(reg);
            return View(reg);
        }

    
        public ActionResult Edit(int id=0)
        {
            if (id==0) return RedirectToAction("TipoComestibles");

            TipoComestible reg = servicio.tipocomestibles().Where(s => s.id == id).FirstOrDefault();
            
           return View(reg);
        }
        [HttpPost]
        public ActionResult Edit(TipoComestible reg)
        {
            ViewBag.mensaje = servicio.ActualizarTipCome(reg);
            return View(reg);
        }

        public ActionResult Delete(TipoComestible reg)
        {
            TempData["mensaje"] = servicio.EliminarTipCome(reg);
            return RedirectToAction("TipoComestibles");
        }
    }
}