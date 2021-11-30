using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_CineALL.ServiceReference1;

namespace Proyecto_CineALL.Controllers
{
    public class PeliculasController : Controller
    {
        Service1Client servicio = new Service1Client();
        public ActionResult Pelicula()
        {
            return View(servicio.listPeliculas());
        }

        public ActionResult Create()
        {
            ViewBag.tipoPelicula = new SelectList(servicio.listTipoPelicula(), "codigo", "descripcion");
            return View(new Peliculas());
        }
        [HttpPost]
        public ActionResult Create(Peliculas reg, HttpPostedFileBase archivo2)
        {
            if (archivo2 == null || archivo2.ContentLength <= 0)
            {
                ViewBag.mensaje = "Seleccione una imagen";
                ViewBag.tipoPelicula = new SelectList(servicio.listTipoPelicula(), "codigo", "descripcion");

                return View(reg);
            }
            //si seleccionaste, lo guardamos en la carpeta FOTOS
            string ruta = "~/FOTOS/" + System.IO.Path.GetFileName(archivo2.FileName);
            reg.rutaimg = ruta;
            archivo2.SaveAs(Server.MapPath(ruta));

            ViewBag.tipoPelicula = new SelectList(servicio.listTipoPelicula(), "codigo", "descripcion");
            ViewBag.mensaje = servicio.addPelicula(reg);
            return View(reg);
        }


        public ActionResult Edit(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return RedirectToAction("Pelicula");
            Peliculas reg = servicio.listPeliculas().Where(x => x.codigo == codigo).FirstOrDefault();
            ViewBag.tipoPelicula = new SelectList(servicio.listTipoPelicula(), "codigo", "descripcion");
            return View(reg);
        }
        [HttpPost]
        public ActionResult Edit(Peliculas reg, HttpPostedFileBase archivo2)
        {
            if (archivo2 != null)
            {
                //si seleccionaste, lo guardamos en la carpeta FOTOS
                string ruta = "~/FOTOS/" + System.IO.Path.GetFileName(archivo2.FileName);
                archivo2.SaveAs(Server.MapPath(ruta));
                reg.rutaimg = ruta;
            }

            ViewBag.mensaje = servicio.updatePelicula(reg);
            ViewBag.tipoPelicula = new SelectList(servicio.listTipoPelicula(), "codigo", "descripcion");
            return View(reg);
        }


        public ActionResult Delete(Peliculas reg)
        {
            TempData["mensaje"] = servicio.deletePelicula(reg);
            return RedirectToAction("Pelicula");
        }
    }
}