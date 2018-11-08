using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPUTERMANAGEMENT_MODEL
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        [DisplayName ("Nombre Completo")]
        public string NombreCompleto { get; set; }
        public string Detalle { get; set; }
        public int? Telefono { get; set; }
        public string Correo { get; set; }
    }
}
