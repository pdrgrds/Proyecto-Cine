using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_CineALL.ServiceReference1;
using Models;
namespace Proyecto_CineALL.Controllers
{
    public class ProveedorController : Controller
    {
        Service1Client servicio = new Service1Client();
        public ActionResult Proveedor()
        {
            return View(servicio.proveedor());
        }


        public ActionResult Create()
        {
            return View(new Proveedor());
        }

        [HttpPost]
        public ActionResult Create(Proveedor reg)
        {
            ViewBag.mensaje = servicio.AgregarProve(reg);
           
            return View(reg);
        }

        public ActionResult Edit(int id=0)
        {
            if (id==0) return RedirectToAction("Proveedor");
            Proveedor reg = servicio.proveedor().Where(s => s.id == id).FirstOrDefault();
            
            return View(reg);
        }
        [HttpPost]
        public ActionResult Edit(Proveedor reg)
        {
            ViewBag.mensaje = servicio.ActualizarProve(reg);
            return View(reg);
        }
        public ActionResult Delete(Proveedor reg)
        {
            TempData["mensaje"] = servicio.EliminarProve(reg);

            return RedirectToAction("Proveedor");
        }
    }
}