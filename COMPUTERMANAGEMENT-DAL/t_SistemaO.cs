//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COMPUTERMANAGEMENT_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_SistemaO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_SistemaO()
        {
            this.t_Producto = new HashSet<t_Producto>();
        }
    
        public int IdSistemaO { get; set; }
        public string SistemaO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Producto> t_Producto { get; set; }
    }
}