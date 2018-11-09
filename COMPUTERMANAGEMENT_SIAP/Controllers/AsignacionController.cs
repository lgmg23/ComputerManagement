using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMPUTERMANAGEMENT_MODEL;

namespace COMPUTERMANAGEMENT_SIAP.Controllers
{
    public class AsignacionController : Controller
    {
        [HttpGet]
        public ActionResult Asignar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Asignar(AsignacionModel model)
        {
            return View();
        }
    }
}