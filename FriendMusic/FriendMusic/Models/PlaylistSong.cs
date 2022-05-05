using FriendMusic.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendMusic.Models
{
    public class PlaylistSong
    {
        public Guid Id { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }


        public static PlaylistSong AddSongToPlaylist(FMContext ctx, int playlistId, int songId)
        {
            var ps = new PlaylistSong()
            {
                PlaylistId = playlistId,
                Playlist = ctx.Playlists.Find(playlistId) ?? new Playlist(),
                SongId = songId,
                Song = ctx.Songs.Find(songId) ?? new Song()
            };
            ctx.SaveChanges();

            return ps;
        }
    }
}
