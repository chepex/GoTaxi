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
    
    public partial class TipoComentario
    {
        public TipoComentario()
        {
            this.comentario = new HashSet<comentario>();
        }
    
        public int idTipoComentario { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<comentario> comentario { get; set; }
    }
}
