using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Proyecto_CineALL.ServiceReference1;

namespace cinemALL_INICIO.Controllers
{
    public class UsuarioController : Controller
    {
        Service1Client servicio = new Service1Client();
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult ValidarUsuario(string usu, string contraseña)
        {
            Usuario reg = servicio.validarUsuario(usu, contraseña);
            if (reg != null)
            {
                //servicio.IniciarSesion(reg);
                System.Web.HttpContext.Current.Session["Usuario"] = reg.usuario;
                System.Web.HttpContext.Current.Session["Tipo"] = reg.idTipo.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["mensaje"] = "Credenciales Incorrectas o Usuario eliminado";
                return RedirectToAction("Login", "Usuario");
            }
        }

    }
}