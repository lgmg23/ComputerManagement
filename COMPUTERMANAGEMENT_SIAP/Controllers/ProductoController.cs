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
        [HttpGet]
        public ActionResult Index()
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            List<t_Producto> productoList = new List<t_Producto>();
            productoList = _context.t_Producto.ToList();
            List<ProductoModel> productoMList = new List<ProductoModel>();
            foreach (var element in productoList)
            {
                ProductoModel productoActual = new ProductoModel();
                TipoModel tipo = new TipoModel();
                MarcaModel marca = new MarcaModel();
                SistemaOModel sistema = new SistemaOModel();
                FacturaModel factura = new FacturaModel();
                tipo.Tipo = element.t_Tipo.Tipo.ToString();
                marca.Marca = element.t_Marca.Marca.ToString();
                sistema.SistemaO = element.t_SistemaO.SistemaO.ToString();
                factura.Factura = element.t_Factura.Factura.ToString();
                productoActual.Marca = marca;
                productoActual.Factura = factura;
                productoActual.Tipo = tipo;
                productoActual.SistemaO = sistema;
                productoActual.Modelo = element.Modelo;
                productoActual.IdProducto = element.IdProducto;
                productoMList.Add(productoActual);
            }
            return View(productoMList);
        }
        [HttpGet]
        public ActionResult WSProductos()
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            List<t_Producto> usuariosM = new List<t_Producto>();
            usuariosM = _context.t_Producto.ToList();
            List<ProductoModel> productoMList = new List<ProductoModel>();
            foreach (t_Producto userActual in usuariosM)
            {
                ProductoModel productoM = new ProductoModel();
                productoM.IdProducto = userActual.IdProducto;
                productoM.Modelo = userActual.Modelo;
                productoMList.Add(productoM);
            }
            return Json(productoMList, JsonRequestBehavior.AllowGet);
        }
    }
}