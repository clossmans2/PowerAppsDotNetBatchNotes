using Microsoft.EntityFrameworkCore;
using FriendMusic.Models;

namespace FriendMusic.Data
{
    public class FMContext : DbContext
    {
        public FMContext()
        {

        }

        public FMContext(DbContextOptions<FMContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>()
            //    .HasOne(p => p.FavoriteSong)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
