//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoTaxiV2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empresa
    {
        public Empresa()
        {
            this.conductor = new HashSet<conductor>();
        }
    
        public int idEmpresa { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string representante { get; set; }
        public string telefono { get; set; }
        public Nullable<int> idPais { get; set; }
        public string correo { get; set; }
    
        public virtual ICollection<conductor> conductor { get; set; }
        public virtual pais pais { get; set; }
    }
}
