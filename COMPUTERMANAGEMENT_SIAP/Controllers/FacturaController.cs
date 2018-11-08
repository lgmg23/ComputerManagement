using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMPUTERMANAGEMENT_DAL;
using COMPUTERMANAGEMENT_MODEL;
using AutoMapper;

namespace COMPUTERMANAGEMENT_SIAP.Controllers
{
    public class FacturaController : Controller
    {
        ///Factura
        ///
        [HttpGet]
        public ActionResult Factura()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Factura(FacturaModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<FacturaModel, t_Factura>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<FacturaModel, t_Factura>(source);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addfactura = _context.t_Factura.Add(destination);
            _context.SaveChanges();
            var data = _context.t_Factura.ToList();
            return View("FacturaList", data);
        }
        [HttpGet]
        public ActionResult FacturaList()
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var data = _context.t_Factura.ToList();
            return View(data);
        }
    }
}