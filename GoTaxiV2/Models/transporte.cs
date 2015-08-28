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
    
    public partial class transporte
    {
        public transporte()
        {
            this.conductor = new HashSet<conductor>();
            this.cotizacion = new HashSet<cotizacion>();
            this.viaje = new HashSet<viaje>();
        }
    
        public int idTransporte { get; set; }
        public Nullable<int> idTipoTransporte { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string placa { get; set; }
        public string propiedad { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public string estado { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public Nullable<int> idEstado { get; set; }
    
        public virtual ICollection<conductor> conductor { get; set; }
        public virtual tipoTransporte tipoTransporte { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual ICollection<cotizacion> cotizacion { get; set; }
        public virtual ICollection<viaje> viaje { get; set; }
        public virtual Estados Estados { get; set; }
    }
}
