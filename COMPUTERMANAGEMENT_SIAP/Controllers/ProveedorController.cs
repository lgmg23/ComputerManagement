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
    public class ProveedorController : Controller
    {
        [HttpGet]
        public ActionResult WSProveedor()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<t_Proveedor, ProveedorModel>();

            });
            List<ProveedorModel> modelList = new List<ProveedorModel>();
            IMapper iMapper = config.CreateMapper();
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            List<t_Proveedor> usuariosT = new List<t_Proveedor>();
            usuariosT = _context.t_Proveedor.ToList();
            foreach (t_Proveedor userActual in usuariosT)
            {
                var source = userActual;
                var destination = iMapper.Map<t_Proveedor, ProveedorModel>(source);
                modelList.Add(destination);
            }
            return Json(modelList, JsonRequestBehavior.AllowGet);
        }
    }
}