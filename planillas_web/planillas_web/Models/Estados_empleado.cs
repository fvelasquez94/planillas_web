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
    
    public partial class Estados_empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estados_empleado()
        {
            this.Empleados = new HashSet<Empleados>();
        }
    
        public int ID_estado { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> ID_empresa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleados> Empleados { get; set; }
        public virtual Empresas Empresas { get; set; }
    }
}
