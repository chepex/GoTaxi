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
    
    public partial class Estados
    {
        public Estados()
        {
            this.roles = new HashSet<roles>();
            this.transporte = new HashSet<transporte>();
            this.Tarifa = new HashSet<Tarifa>();
        }
    
        public int idEstado { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<roles> roles { get; set; }
        public virtual ICollection<transporte> transporte { get; set; }
        public virtual ICollection<Tarifa> Tarifa { get; set; }
    }
}
