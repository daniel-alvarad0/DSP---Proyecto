﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibliotecaMetrópolis
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Biblioteca_Metropolis_newEntities : DbContext
    {
        public Biblioteca_Metropolis_newEntities()
            : base("name=Biblioteca_Metropolis_newEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<AutoresRecursos> AutoresRecursos { get; set; }
        public virtual DbSet<DVD> DVD { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Enciclopedia> Enciclopedia { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Revista> Revista { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tesis> Tesis { get; set; }
    }
}
