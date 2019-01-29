using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPUTERMANAGEMENT_MODEL
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public virtual TipoModel Tipo { get; set; }
        public virtual MarcaModel Marca { get; set; }
        public string Modelo { get; set; }
        public virtual SistemaOModel SistemaO { get; set; }
        public virtual FacturaModel Factura { get; set; }
    }
}
