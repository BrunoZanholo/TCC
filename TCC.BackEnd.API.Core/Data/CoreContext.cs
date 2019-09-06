using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCC.BackEnd.API.Core.Models;

namespace TCC.BackEnd.API.Core.Data
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sensor>(model =>
            {
                model.ToTable("SENSORES");
            });

            modelBuilder.Entity<Incidente>(model =>
            {
                model.ToTable("INCIDENTES");
            });

            modelBuilder.Entity<PlanoAcao>(model =>
            {
                model.ToTable("PLANOSACAO");
            });

            modelBuilder.Entity<Area>(model =>
            {
                model.ToTable("AREAS");
            });

            modelBuilder.Entity<Afetado>(model =>
            {
                model.ToTable("AFETADOS");
            });

            modelBuilder.Entity<Atividade>(model =>
            {
                model.ToTable("ATIVIDADES");
            });
        }

        public DbSet<Sensor> Sensores { get; set; }

        public DbSet<Incidente> Incidentes { get; set; }

        public DbSet<PlanoAcao> PlanosAcao { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Afetado> Afetados { get; set; }

        public DbSet<Atividade> Atividades { get; set; }
    }
}