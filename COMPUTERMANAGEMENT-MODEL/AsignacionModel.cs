using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPUTERMANAGEMENT_MODEL
{
    public class AsignacionModel
    {
        public int IdAsignacion { get; set; }
        public virtual EquipoModel Equipo { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}