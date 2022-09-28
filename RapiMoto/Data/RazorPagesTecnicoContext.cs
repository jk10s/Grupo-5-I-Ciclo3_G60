using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RapiMoto.Models;

    public class RazorPagesTecnicoContext : DbContext
    {
        public RazorPagesTecnicoContext (DbContextOptions<RazorPagesTecnicoContext> options)
            : base(options)
        {
        }

        public DbSet<RapiMoto.Models.Tecnico> Tecnico { get; set; } = default!;

        public DbSet<RapiMoto.Models.TipoServicio>? TipoServicio { get; set; }

        public DbSet<RapiMoto.Models.Administrador>? Administrador { get; set; }

        public DbSet<RapiMoto.Models.Cliente>? Cliente { get; set; }

        public DbSet<RapiMoto.Models.HistorialCliente>? HistorialCliente { get; set; }

        public DbSet<RapiMoto.Models.HitorialTecnico>? HitorialTecnico { get; set; }

        public DbSet<RapiMoto.Models.Servicio>? Servicio { get; set; }

        public DbSet<RapiMoto.Models.TipoAdmin>? TipoAdmin { get; set; }
    }
