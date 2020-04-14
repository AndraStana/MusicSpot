using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Infrastructure
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {

        //public class ApplicationUser : IdentityUser
        //{
        //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //    {
        //        var userIdentity = await manager.CreateAsync(this);
        //        return userIdentity;
        //    }
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibrarySong> LibrarySong { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<PopularityRanking> PopularityRankings { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<SimilarArtistsRelationship> SimilarArtistsRelationships { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<Friendship>()
           .HasOne(m => m.FirstFriend)
            .WithMany(m => m.FirstFriends)
            .HasForeignKey(p => p.FirstFriendId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Friendship>()
          .HasOne(m => m.SecondFriend)
            .WithMany(m => m.SecondFriends)
           .HasForeignKey(p => p.SecondFriendId).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<SimilarArtistsRelationship>()
         .HasOne(m => m.FirstArtist)
          .WithMany(m => m.FirstArtists)
          .HasForeignKey(p => p.FirstArtistId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SimilarArtistsRelationship>()
        .HasOne(m => m.SecondArtist)
            .WithMany(m => m.SecondArtists)
            .HasForeignKey(p => p.SecondArtistId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
