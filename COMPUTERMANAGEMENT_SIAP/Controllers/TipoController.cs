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
    public class TipoController : Controller
    {
        [HttpGet]
        public ActionResult WSTipo()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<t_Tipo, TipoModel>();

            });
            List<TipoModel> modelList = new List<TipoModel>();
            IMapper iMapper = config.CreateMapper();
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            List<t_Tipo> usuariosT = new List<t_Tipo>();
            usuariosT = _context.t_Tipo.ToList();
            foreach (t_Tipo userActual in usuariosT)
            {
                var source = userActual;
                var destination = iMapper.Map<t_Tipo, TipoModel>(source);
                modelList.Add(destination);
            }
            return Json(modelList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AgregarTipo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarTipo(TipoModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<TipoModel, t_Tipo>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<TipoModel, t_Tipo>(source);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addfactura = _context.t_Tipo.Add(destination);
            _context.SaveChanges();
            var data = _context.t_Tipo.ToList();
            return View("TipoList", data);
        }
        [HttpGet]
        public ActionResult TipoList()
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var data = _context.t_Tipo.ToList();
            return View(data);
        }
    }
}