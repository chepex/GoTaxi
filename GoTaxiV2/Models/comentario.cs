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
    
    public partial class comentario
    {
        public comentario()
        {
            this.viaje = new HashSet<viaje>();
        }
    
        public int idComentario { get; set; }
        public System.DateTime fecha { get; set; }
        public string comentario1 { get; set; }
        public Nullable<int> idTipoComentario { get; set; }
    
        public virtual TipoComentario TipoComentario { get; set; }
        public virtual ICollection<viaje> viaje { get; set; }
    }
}
