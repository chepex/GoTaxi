﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SIGTPPEntities : DbContext
    {
        public SIGTPPEntities()
            : base("name=SIGTPPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<conductor> conductor { get; set; }
        public DbSet<roles> roles { get; set; }
        public DbSet<tipoTransporte> tipoTransporte { get; set; }
        public DbSet<transporte> transporte { get; set; }
        public DbSet<usuario> usuario { get; set; }
        public DbSet<cotizacion> cotizacion { get; set; }
        public DbSet<viaje> viaje { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<pais> pais { get; set; }
        public DbSet<permisos> permisos { get; set; }
        public DbSet<Recorrido> Recorrido { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<TipoComentario> TipoComentario { get; set; }
        public DbSet<comentario> comentario { get; set; }
        public DbSet<Tarifa> Tarifa { get; set; }
    }
}