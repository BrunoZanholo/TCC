using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCC.BackEnd.API.Monitoramento.Models;

    public class TCCBackEndAPIMonitoramentoContext : DbContext
    {
        public TCCBackEndAPIMonitoramentoContext (DbContextOptions<TCCBackEndAPIMonitoramentoContext> options)
            : base(options)
        {
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TCC.BackEnd.API.Monitoramento.Models.Sensor>(model =>
        {
            model.ToTable("SENSORES");
        });
    }

    public DbSet<TCC.BackEnd.API.Monitoramento.Models.Sensor> Sensor { get; set; }
    }
