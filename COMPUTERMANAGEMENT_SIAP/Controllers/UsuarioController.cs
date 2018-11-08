using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using COMPUTERMANAGEMENT_MODEL;
using COMPUTERMANAGEMENT_DAL;
using AutoMapper;

namespace COMPUTERMANAGEMENT_SIAP.Controllers
{
    public class UsuarioController : Controller
    {
        static DirectoryEntry conexionAD()
        {
            // create and return new LDAP connection with desired settings  
            DirectoryEntry cnAD = new DirectoryEntry("LDAP://GAP.NET", "soportea.ext2", "Gerard1995#");
            cnAD.Path = "LDAP://MADRIGALDEV.NET";
            cnAD.AuthenticationType = AuthenticationTypes.Secure;
            return cnAD;
        }
        [HttpGet]
        public ActionResult UsuarioBusqueda()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UsuarioBusqueda(UsuarioBusquedaModel usuarioModel)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<UsuarioModel, t_Usuario>();

            });
            IMapper iMapper = config.CreateMapper();
            var usuario = usuarioModel.Usuario;
            DirectoryEntry adCN = new DirectoryEntry("LDAP://GAP.NET", "soportea.ext2", "Gerard1995#");
            DirectorySearcher busqueda = new DirectorySearcher(adCN);            
            busqueda.Filter = "(&(objectCategory=person)(objectClass=user)(|(displayName=*" + usuario + "*)(givenName=*" + usuario + "*)(samaccountname=*" + usuario + "*)(sn=*" + usuario + "*)))";
            var results = busqueda.FindAll();
            List<UsuarioModel> modelList = new List<UsuarioModel>();
            if (results != null)
            {
                foreach (SearchResult result in results)
                {
                    if (result.Properties["distinguishedname"] != null && result.Properties["distinguishedname"].Count > 0)
                    {
                        UsuarioModel model = new UsuarioModel();
                        COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
                        string user = result.Properties["samaccountname"][0].ToString();
                        var checkIfExists = _context.t_Usuario.FirstOrDefault(x => x.Usuario == user);
                        if (checkIfExists == null)
                        {
                            model.Usuario = result.Properties["samaccountname"][0].ToString();
                            model.NombreCompleto = result.Properties["cn"][0].ToString();
                            model.Detalle = result.Properties["description"][0].ToString();
                            if (result.Properties["telephonenumber"].Count > 0 && result.Properties["mail"].Count > 0)
                            {
                                model.Correo = result.Properties["mail"][0].ToString();
                                int telefonoA = 0;
                                Int32.TryParse(result.Properties["telephonenumber"][0].ToString(), out telefonoA);
                                model.Telefono = telefonoA;
                            }
                            var source = model;
                            modelList.Add(source);
                            var destination = iMapper.Map<UsuarioModel, t_Usuario>(source);
                            _context.t_Usuario.Add(destination);
                            _context.SaveChanges();
                        }
                    }
                }
            }            
            return View("Usuarios", modelList);
        }
        [HttpGet]
        public ActionResult UsuarioDetalle(int id)
        {
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            t_Usuario usuarioT = new t_Usuario();
            usuarioT = _context.t_Usuario.FirstOrDefault(x => x.IdUsuario == id);
            return View(usuarioT);
        }
        [HttpGet]
        public ActionResult Usuarios()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<t_Usuario, UsuarioModel>();

            });
            IMapper iMapper = config.CreateMapper();
            COMPUTERMANAGEMENT_TestEntities _context = new COMPUTERMANAGEMENT_TestEntities();
            List<t_Usuario> usuarioTList = new List<t_Usuario>();
            List<UsuarioModel> usuarioMList = new List<UsuarioModel>();
            usuarioTList = _context.t_Usuario.ToList();      
            foreach (t_Usuario element in usuarioTList)
            {
                var source = element;
                var destination = iMapper.Map<t_Usuario, UsuarioModel>(source);
                usuarioMList.Add(destination);
            }
            return View(usuarioMList);
        }
    }
}