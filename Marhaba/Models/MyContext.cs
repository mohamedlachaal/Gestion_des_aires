using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marhaba.Models
{
    public class MyContext :DbContext
    {
        public DbSet<Aire> aires { get; set; }
        public DbSet<Reservation> reservations{ get; set; }
        public DbSet<Ville> villes{ get; set; }
        public DbSet<Passager> Passagers{ get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reservation>().HasKey(r => new { r.AireId, r.PassagerId });
        }
    }
}
