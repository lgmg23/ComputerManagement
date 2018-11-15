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
    public class SistemaOController : Controller
    {
        [HttpGet]
        public ActionResult WSSistemaO()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<t_SistemaO, SistemaOModel>();

            });
            List<SistemaOModel> modelList = new List<SistemaOModel>();
            IMapper iMapper = config.CreateMapper();
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            List<t_SistemaO> usuariosT = new List<t_SistemaO>();
            usuariosT = _context.t_SistemaO.ToList();
            foreach (t_SistemaO userActual in usuariosT)
            {
                var source = userActual;
                var destination = iMapper.Map<t_SistemaO, SistemaOModel>(source);
                modelList.Add(destination);
            }
            return Json(modelList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AgregarSistemaO()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarSistemaO(SistemaOModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<SistemaOModel, t_SistemaO>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<SistemaOModel, t_SistemaO>(source);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addfactura = _context.t_SistemaO.Add(destination);
            _context.SaveChanges();
            var data = _context.t_SistemaO.ToList();
            return View("SistemaOList", data);
        }
        [HttpGet]
        public ActionResult SistemaOList()
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var data = _context.t_SistemaO.ToList();
            return View(data);
        }
    }
}