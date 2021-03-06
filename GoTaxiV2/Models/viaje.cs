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
    
    public partial class viaje
    {
        public viaje()
        {
            this.Recorrido = new HashSet<Recorrido>();
        }
    
        public int idViaje { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public int idConductor { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string valor { get; set; }
        public Nullable<int> idTransporte { get; set; }
        public Nullable<int> calificacion { get; set; }
        public Nullable<int> idComentario { get; set; }
        public Nullable<int> idEstado { get; set; }
    
        public virtual comentario comentario { get; set; }
        public virtual conductor conductor { get; set; }
        public virtual ICollection<Recorrido> Recorrido { get; set; }
        public virtual transporte transporte { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual Estados Estados { get; set; }
    }
}
