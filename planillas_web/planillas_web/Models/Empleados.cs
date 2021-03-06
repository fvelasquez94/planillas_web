//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleados()
        {
            this.Egresos_empleados = new HashSet<Egresos_empleados>();
            this.Ingresos_empleados = new HashSet<Ingresos_empleados>();
        }
    
        public int ID_empleado { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dui { get; set; }
        public string nit { get; set; }
        public string celular { get; set; }
        public int edad { get; set; }
        public string estado_civil { get; set; }
        public int horas_laborales { get; set; }
        public decimal salario_mensual { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime fecha_nacimiento { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime fecha_contratacion { get; set; }
        public int ID_cargo { get; set; }
        public int ID_departamento { get; set; }
        public int ID_estado { get; set; }
        public int ID_empresa { get; set; }
    
        public virtual Cargos Cargos { get; set; }
        public virtual Departamentos Departamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egresos_empleados> Egresos_empleados { get; set; }
        public virtual Empresas Empresas { get; set; }
        public virtual Estados_empleado Estados_empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingresos_empleados> Ingresos_empleados { get; set; }
    }
}
