﻿using AutoMapper;
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
        [HttpGet]
        public ActionResult AgregarProveedor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarProveedor(ProveedorModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ProveedorModel, t_Proveedor>();

            });
            IMapper iMapper = config.CreateMapper();
            var source = model;
            var destination = iMapper.Map<ProveedorModel, t_Proveedor>(source);
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var addfactura = _context.t_Proveedor.Add(destination);
            _context.SaveChanges();            
            var data = _context.t_Proveedor.ToList();
            return View("ProveedorList", data);
        }
        [HttpGet]
        public ActionResult ProveedorList()
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            var data = _context.t_Proveedor.ToList();
            return View(data);            
        }

    }
}