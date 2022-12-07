using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class TuPencaContext : IdentityDbContext<Users>
    {
        public TuPencaContext()
        {
        }

        public TuPencaContext(DbContextOptions<TuPencaContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Penca;User Id=sa;Password=1234;");
                //optionsBuilder.UseSqlServer("Server=localhost,14330;Database=TuPenca;User Id=sa;Password=Tisj*2022!;");
            }
        }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Premio> Premios { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Penca> Penca { get; set; }
        public DbSet<User_Penca> User_Penca { get; set; }
        public DbSet<Predicsion> Predicsion { get; set; }
    }
}
