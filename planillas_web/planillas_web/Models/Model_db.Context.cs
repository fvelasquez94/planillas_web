﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace planillas_web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Planillas_webEntities : DbContext
    {
        public Planillas_webEntities()
            : base("name=Planillas_webEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Egresos_empleados> Egresos_empleados { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Estados_empleado> Estados_empleado { get; set; }
        public virtual DbSet<Ingresos_empleados> Ingresos_empleados { get; set; }
        public virtual DbSet<Tipo_usuarios> Tipo_usuarios { get; set; }
        public virtual DbSet<Tipos_egresos> Tipos_egresos { get; set; }
        public virtual DbSet<Tipos_ingresos> Tipos_ingresos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
