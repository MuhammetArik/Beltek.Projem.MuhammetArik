using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beltek.Projem.MuhammetArik.Models;

namespace Beltek.Projem.MuhammetArik.Models
{
    public class HastaneContext : DbContext
    {
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Klinik> Klinikler { get; set; }

        public DbSet<RandevuAl> Randevular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RandevuAl>().HasKey(c => new { c.HastaId, c.KlinikId, c.DoktorId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=HastaneDb; Integrated Security=true");
        }
    }
}