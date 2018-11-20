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
    public class ProductoController : Controller
    {
        [HttpGet]
        public ActionResult AgregarProducto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarProducto(ProductoTModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ProductoTModel, t_Producto>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<ProductoTModel, t_Producto>(source);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addfactura = _context.t_Producto.Add(destination);
            _context.SaveChanges();
            var data = _context.t_Tipo.ToList();
            return View("AgregarProducto");
        }       
    }
}
