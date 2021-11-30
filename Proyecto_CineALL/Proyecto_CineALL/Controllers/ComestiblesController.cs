using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_CineALL.ServiceReference1;
using System.Data.SqlClient;
using Models;

namespace Proyecto_CineALL.Controllers
{
    public class ComestiblesController : Controller
    {
        Service1Client servicio = new Service1Client();
        public ActionResult Comestible()
        {
            return View(servicio.comestibles());
        }

        public ActionResult Create()
        {
            ViewBag.tipcomestibles = new SelectList(servicio.tipocomestibles(), "id", "descrip");
            ViewBag.proveedor = new SelectList(servicio.proveedor(), "id", "nombre");
            return View(new Comestibles());
        }

        [HttpPost]
        public ActionResult Create(Comestibles reg, HttpPostedFileBase archivo)
        {
            if (archivo == null || archivo.ContentLength <= 0)
            {
                ViewBag.mensaje = "Seleccione una imagen";
                ViewBag.tipcomestibles = new SelectList(servicio.tipocomestibles(), "id", "descrip");
                ViewBag.proveedor = new SelectList(servicio.proveedor(), "id", "nombre");
                return View(reg);
            }
            //si seleccionaste, lo guardamos en la carpeta FOTOS
            string ruta = "~/FOTOS/" + System.IO.Path.GetFileName(archivo.FileName);
            reg.rutaimg = ruta;
            archivo.SaveAs(Server.MapPath(ruta));

            ViewBag.mensaje = servicio.AgregarCome(reg);
            ViewBag.tipcomestibles = new SelectList(servicio.tipocomestibles(), "id", "descrip", reg.id_Tipo);
            ViewBag.proveedor = new SelectList(servicio.proveedor(), "id", "nombre", reg.id_proveedor);
            return View(reg);
        }

        public ActionResult Edit(string cod_Com)
        {
            if (string.IsNullOrEmpty(cod_Com)) return RedirectToAction("Index");
            Comestibles reg = servicio.comestibles().Where(s => s.cod_Com == cod_Com).FirstOrDefault();
            ViewBag.tipcomestibles = new SelectList(servicio.tipocomestibles(), "id", "descrip", reg.id_Tipo);
            ViewBag.proveedor = new SelectList(servicio.proveedor(), "id", "nombre", reg.id_proveedor);
            return View(reg);
        }
        [HttpPost]
        public ActionResult Edit(Comestibles reg, HttpPostedFileBase archivo)
        {
            if (archivo != null)
            {
                //si seleccionaste, lo guardamos en la carpeta FOTOS
                string ruta = "~/FOTOS/" + System.IO.Path.GetFileName(archivo.FileName);
                archivo.SaveAs(Server.MapPath(ruta));
                reg.rutaimg = ruta;
            }

            ViewBag.mensaje = servicio.ActualizarCome(reg);
            ViewBag.tipcomestibles = new SelectList(servicio.tipocomestibles(), "id", "descrip", reg.id_Tipo);
            ViewBag.proveedor = new SelectList(servicio.proveedor(), "id", "nombre", reg.id_proveedor);
            return View(reg);
        }
        public ActionResult Delete(Comestibles reg)
        {
            TempData["mensaje"] = servicio.EliminarCome(reg);

            return RedirectToAction("Comestible");
        }
    }

}