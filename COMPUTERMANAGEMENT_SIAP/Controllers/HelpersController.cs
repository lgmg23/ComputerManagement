using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using COMPUTERMANAGEMENT_MODEL;
using COMPUTERMANAGEMENT_DAL;
using AutoMapper;

namespace COMPUTERMANAGEMENT_SIAP.Controllers
{
    public class HelpersController : Controller
    {
        /// <summary>
        /// Seccion del codigo destinada para controladores auxiliares.
        /// 
        /// Controladores que cumplen su funcion como llaves foraneas.
        /// </summary>
        /// <returns></returns>
        /// 
        //Tipo
        [HttpGet]
        public ActionResult Tipo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Tipo(TipoModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<TipoModel, t_Tipo>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<TipoModel, t_Tipo>(source);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addTipo = _context.t_Tipo.Add(destination);
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
        /// 
        //Marca
        [HttpGet]
        public ActionResult Marca()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Marca(MarcaModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<MarcaModel, t_Marca>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<MarcaModel, t_Marca>(model);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addMarca = _context.t_Marca.Add(destination);
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
        /// 
        //SistemaO
        [HttpGet]
        public ActionResult SistemaO()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SistemaO(SistemaOModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<SistemaOModel, t_SistemaO>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<SistemaOModel, t_SistemaO>(model);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addMarca = _context.t_SistemaO.Add(destination);
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
        /// 
        //Modelo
        [HttpGet]
        public ActionResult Modelo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Modelo(ModeloModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ModeloModel, t_Modelo>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<ModeloModel, t_Modelo>(model);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addMarca = _context.t_Modelo.Add(destination);
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