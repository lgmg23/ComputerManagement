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
    public class MarcaController : Controller
    {
        [HttpGet]
        public ActionResult WSMarca()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<t_Marca, MarcaModel>();

            });
            List<MarcaModel> modelList = new List<MarcaModel>();
            IMapper iMapper = config.CreateMapper();
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            List<t_Marca> usuariosT = new List<t_Marca>();
            usuariosT = _context.t_Marca.ToList();
            foreach (t_Marca userActual in usuariosT)
            {
                var source = userActual;
                var destination = iMapper.Map<t_Marca, MarcaModel>(source);
                modelList.Add(destination);
            }
            return Json(modelList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AgregarMarca()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarMarca(MarcaModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<MarcaModel, t_Marca>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<MarcaModel, t_Marca>(source);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addfactura = _context.t_Marca.Add(destination);
            _context.SaveChanges();
            var data = _context.t_Marca.ToList();
            return View("MarcaList", data);
        }
        [HttpGet]
        public ActionResult MarcaList()
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var data = _context.t_Marca.ToList();
            return View(data);
        }
    }
}