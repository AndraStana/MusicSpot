using Microsoft.EntityFrameworkCore;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Infrastructure
{
    class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\SQLEXPRESS;Database=MusicSpot;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}
