using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPUTERMANAGEMENT_MODEL
{
    public class FacturaModel
    {
        public int IdFactura { get; set; }
        public string Factura { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Garantia { get; set; }
        public string Proveedor { get; set; }
    }
}
