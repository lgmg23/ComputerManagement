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
    
    public partial class t_NombreEquipo
    {
        public int IdNombreEquipo { get; set; }
        public int Usuario { get; set; }
        public int Equipo { get; set; }
    
        public virtual t_Equipo t_Equipo { get; set; }
        public virtual t_Usuario t_Usuario { get; set; }
    }
}
