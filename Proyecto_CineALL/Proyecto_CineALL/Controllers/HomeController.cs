using Models;
using Proyecto_CineALL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_CineALL.Controllers
{
    public class HomeController : Controller
    {
        Service1Client servicio = new Service1Client();
        public ActionResult Index()
        {
            if (Session["carrito"] == null) Session["carrito"] = new List<Carrito>();
            if (Session["carrito"] == null) Session["usuario"] = new Usuario();
            ViewBag.listaPelicula = servicio.listPeliculas().Where(x => x.entradasRestantes > 0);
            ViewBag.listaComestible = servicio.comestibles().Where(x => x.stock_Actual > 0);
            return View();
        }

        public ActionResult Seleccionar(string codigo="", int tipo = 0)
        {
            Carrito temp = null;
            if (tipo == 1)
            {
                Peliculas reg = servicio.listPeliculas().Where(x => x.codigo == codigo).FirstOrDefault();
                temp = new Carrito()
                {
                    codigoProducto = reg.codigo,
                    stock = reg.entradasRestantes,
                    descripcion = reg.nombre,
                    precio = reg.precio,
                    tipo = 1,
                    rutaimg = reg.rutaimg
                };
            }
            else if (tipo == 2)
            {
                Comestibles reg = servicio.comestibles().Where(x => x.cod_Com == codigo).FirstOrDefault();
                temp = new Carrito()
                {
                    codigoProducto = reg.cod_Com,
                    stock = reg.stock_Actual,
                    descripcion = reg.descrip,
                    precio = reg.precio,
                    tipo = 2,
                    rutaimg = reg.rutaimg
                };
            }
            else {
                return RedirectToAction("Index");
            }

            
            if (temp.codigoProducto == null) return RedirectToAction("Index");

            Boolean exists = (Session["carrito"] as List<Carrito>).Exists(p => p.codigoProducto == codigo) ? true : false;
            if (exists == true) {
                ViewBag.d = exists;
                ViewBag.mensaje = "Producto ya esta registrado en el carrito";
            }

            return View(temp);
        }
    
        
        [HttpPost] public ActionResult Seleccionar(string codigo, int tipo, int cantidad)
        {
            Carrito temp = null;

            if (tipo == 1)
            {
                Peliculas reg = servicio.listPeliculas().Where(x => x.codigo == codigo).FirstOrDefault();
                temp = new Carrito()
                {
                    codigoProducto = reg.codigo,
                    stock = reg.entradasRestantes,
                    descripcion = reg.nombre,
                    precio = reg.precio,
                    cantidad = cantidad,
                    tipo = 1,
                    rutaimg = reg.rutaimg
                };
            }
            else
            {
                Comestibles reg = servicio.comestibles().Where(x => x.cod_Com == codigo).FirstOrDefault();
                temp = new Carrito()
                {
                    codigoProducto = reg.cod_Com,
                    stock = reg.stock_Actual,
                    descripcion = reg.descrip,
                    precio = reg.precio,
                    cantidad = cantidad,
                    tipo = 2,
                    rutaimg = reg.rutaimg
                };
            }

            if (cantidad > temp.stock || cantidad <= 0) {
                ViewBag.mensaje = "Stock insuficiente/invalido";
                return View(temp);
            }

            (Session["carrito"] as List<Carrito>).Add(temp);
            ViewBag.d = true;

            ViewBag.mensaje = "Produco Agregado";
            return View(temp);
        }

        public ActionResult Carrito()
        {
            
            if (Session["carrito"] == null) 
                return RedirectToAction("Index");
            else
                return View(Session["carrito"] as List<Carrito>);
        }

        [HttpPost] public ActionResult Actualizar(string codigo, int q)
        {
            Carrito reg = (Session["carrito"] as List<Carrito>).Where(p => p.codigoProducto == codigo).FirstOrDefault();
            if (reg.stock < q)
            {
                TempData["mensajeCarrito"] = "Stock insuficiente, máximo: " + reg.stock;
                return RedirectToAction("Carrito");
            }
            reg.cantidad = q;

            return RedirectToAction("Carrito");
        }

        public ActionResult Delete(string codigo)
        {
            //buscar el item del session carrito por su codigo y quitarlo
            Carrito reg = (Session["carrito"] as List<Carrito>).Find(p => p.codigoProducto == codigo);

            (Session["carrito"] as List<Carrito>).Remove(reg);
            //refrescar
            return RedirectToAction("Carrito");
        }

        public ActionResult Comprar()
        {
            string Usuario = System.Web.HttpContext.Current.Session["Usuario"] as String;
            List<Carrito> temp = Session["carrito"] as List<Carrito>;
            if (Usuario == null)
                return RedirectToAction("Index");

            if (Session["carrito"] == null || temp.Count == 0) 
                return RedirectToAction("Index");

            Boleta bol = new Boleta();
            bol.codigoUsuario = Usuario;
            ViewBag.Usuario = Usuario;

            return View(bol);
        }

        [HttpPost]
        public ActionResult Comprar(Boleta reg)
        {
            if (Session["carrito"] == null) 
                return RedirectToAction("Index");
            else if ((Session["carrito"] as List<Carrito>).Count == 0)
            {
                ViewBag.mensaje = "Debe agregar productos a su canaste";
                return View(reg);
            }
            else
            {
                List<Carrito> temp1 = (Session["carrito"] as List<Carrito>).ToList();
                reg.precioTotal = temp1.Sum(i => i.monto);

                ViewBag.mensaje = servicio.Transaccion(reg, temp1);
                Session["carrito"] = null;
                //Session.Abandon();
                return View(reg);
            }
        }






        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}