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

        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Playlist> Playlists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>()
            //    .HasOne(p => p.FavoriteSong)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
