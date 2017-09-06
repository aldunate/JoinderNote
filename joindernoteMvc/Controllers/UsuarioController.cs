using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace joindernoteMvc.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Registrarse()
        {
            return View();
        }
    }
}