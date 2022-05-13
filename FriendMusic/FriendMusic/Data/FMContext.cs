using FriendMusic.Models;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Person>(person =>
            {
                person.HasMany(p => p.OwnedPlaylists)
                      .WithOne(p => p.Owner);

                person.HasMany(p => p.LikedPlaylists)
                      .WithMany(p => p.LikedBy)
                      .UsingEntity<LikedPlaylist>();

                person.HasOne(p => p.FavoriteSong)
                      .WithMany();
            });


            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasMany(p => p.LikedBy)
                    .WithMany(p => p.LikedPlaylists)
                    .UsingEntity<LikedPlaylist>();

                entity.HasMany(p => p.Songs)
                    .WithMany(s => s.Playlists)
                    .UsingEntity<PlaylistSong>();
            });
        }
    }
}
