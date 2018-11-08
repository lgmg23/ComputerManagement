using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPUTERMANAGEMENT_MODEL
{
    public class EquipoModel
    {
        public int IdEquipo { get; set; }
        public virtual ProductoModel Producto { get; set; }
        public string Serie { get; set; }
    }
}
