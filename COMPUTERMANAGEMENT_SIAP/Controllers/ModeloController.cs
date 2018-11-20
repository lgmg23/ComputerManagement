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
    public class ModeloController : Controller
    {
        [HttpGet]
        public ActionResult WSModelo()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<t_Modelo, ModeloModel>();

            });
            List<ModeloModel> modelList = new List<ModeloModel>();
            IMapper iMapper = config.CreateMapper();
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            List<t_Modelo> usuariosT = new List<t_Modelo>();
            usuariosT = _context.t_Modelo.ToList();
            foreach (t_Modelo userActual in usuariosT)
            {
                var source = userActual;
                var destination = iMapper.Map<t_Modelo, ModeloModel>(source);
                modelList.Add(destination);
            }
            return Json(modelList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AgregarModelo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarModelo(ModeloModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ModeloModel, t_Modelo>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<ModeloModel, t_Modelo>(source);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addfactura = _context.t_Modelo.Add(destination);
            _context.SaveChanges();
            var data = _context.t_Modelo.ToList();
            return View("ModeloList", data);
        }
        [HttpGet]
        public ActionResult ModeloList()
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var data = _context.t_Modelo.ToList();
            return View(data);
        }
    }
}
