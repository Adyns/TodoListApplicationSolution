﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoListApplication.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ToDoListEntities : DbContext
    {
        public ToDoListEntities()
            : base("name=ToDoListEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departmanlar> Departmanlars { get; set; }
        public virtual DbSet<Etiketler> Etiketlers { get; set; }
        public virtual DbSet<Gorevler> Gorevlers { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Durumlar> Durumlars { get; set; }
        public virtual DbSet<Projeler> Projelers { get; set; }
    }
}
