﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class COMPUTERMANAGEMENT_TestEntities : DbContext
    {
        public COMPUTERMANAGEMENT_TestEntities()
            : base("name=COMPUTERMANAGEMENT_TestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<t_Asignacion> t_Asignacion { get; set; }
        public virtual DbSet<t_Equipo> t_Equipo { get; set; }
        public virtual DbSet<t_Factura> t_Factura { get; set; }
        public virtual DbSet<t_Marca> t_Marca { get; set; }
        public virtual DbSet<t_NombreEquipo> t_NombreEquipo { get; set; }
        public virtual DbSet<t_Producto> t_Producto { get; set; }
        public virtual DbSet<t_Proveedor> t_Proveedor { get; set; }
        public virtual DbSet<t_SistemaO> t_SistemaO { get; set; }
        public virtual DbSet<t_Tipo> t_Tipo { get; set; }
        public virtual DbSet<t_Usuario> t_Usuario { get; set; }
    }
}
