﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConsorcioCtx : DbContext
    {
        public ConsorcioCtx()
            : base("name=ConsorcioCtx")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Consorcio> Consorcios { get; set; }
        public virtual DbSet<Gasto> Gastoes { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<TipoGasto> TipoGastoes { get; set; }
        public virtual DbSet<Unidad> Unidads { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
