using planillas_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace planillas_web.Controllers
{
    public class HomeController : Controller
    {
        private Planillas_webEntities db = new Planillas_webEntities();
        public ActionResult Index()
        {

            return View();


        }

        public ActionResult Main()
        {

            return View();
        }

        public ActionResult Login()
        {


            return View();
        }

        public ActionResult Iniciar_sesion(string correo, string password)

        {
            //Validamos del lado del cliente que ambos parametros no vengan vacios
         try
            {
                var obj = (from c in db.Usuarios where (c.correo == correo && c.contrasena == password) select c).FirstOrDefault();
                if (obj != null)

                {
                    Session["ID_empresa"] = obj.ID_empresa.ToString();
                    Session["tipousuario"] = obj.ID_tipousuario.ToString();

                    return RedirectToAction("Main");

                }

                else

                {
                    //Si ingreso mal la contraseña o el usuario no existe
                    TempData["error"] = "Correo o contrasena incorrecta.";
                    return RedirectToAction("Login");

                }

            }

            catch (Exception ex)

            {
                TempData["error"] = "Ocurrio un error : " + ex.Message;
                return RedirectToAction("Login");

            }

        }

        public ActionResult Cerrar_sesion()

        {

            Session.RemoveAll();
            return RedirectToAction("Index");

        }

    }
}