using AutoMapper;
using COMPUTERMANAGEMENT_DAL;
using COMPUTERMANAGEMENT_MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COMPUTERMANAGEMENT_SIAP.Controllers
{
    public class EquipoController : Controller
    {
        [HttpGet]
        public ActionResult AgregarEquipo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarEquipo(EquipoTModel model)
        {
            t_Equipo tablaEquipo = new t_Equipo();
            tablaEquipo.IdEquipo = model.IdEquipo;
            tablaEquipo.Producto = model.Producto;
            tablaEquipo.Serie = model.Serie;
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addEquipo = _context.t_Equipo.Add(tablaEquipo);
            _context.SaveChanges();
            var data = _context.t_Equipo.ToList();
            //return View("EquiposList", data);
            return View("AgregarEquipo");
        }
        [HttpGet]
        public ActionResult EquiposList()
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            List<t_Equipo> equipoT = new List<t_Equipo>();
            equipoT = _context.t_Equipo.ToList();
            return View(equipoT);
        }

    }
}