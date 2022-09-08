using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RapiMotos.App.Dominio;
using Microsoft.EntityFrameworkCore; 

namespace RapiMotos.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<HistorialCliente> HistorialCliente { get; set; }
        public DbSet<HitorialTecnico> HitorialTecnico { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Tecnico> Tecnico { get; set; }
        public DbSet<TipoServicio> TipoServicio { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder
            .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RapiMotos ");
        }
    }   
    }
}