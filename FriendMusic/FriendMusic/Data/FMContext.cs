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
            modelBuilder.Entity<Person>()
                .HasMany(p => p.OwnedPlaylists)
                .WithOne(p => p.Owner);

            modelBuilder.Entity<LikedPlaylist>()
                .HasOne<Person>()
                .WithMany(p => p.LikedPlaylists)
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LikedPlaylist>()
                .HasOne(p => p.Playlist)
                .WithMany()
                .HasForeignKey(p => p.PlaylistId);


            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Songs)
                .WithOne(ps => ps.Playlist)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.Playlists)
                .HasForeignKey(ps => ps.SongId);
                
        }
    }
}
