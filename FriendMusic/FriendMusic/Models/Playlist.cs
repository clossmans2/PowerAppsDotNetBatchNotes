using System.ComponentModel.DataAnnotations.Schema;

namespace FriendMusic.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Person? Owner { get; set; } = null!;

        public ICollection<PlaylistSong>? Songs { get; set; } = new List<PlaylistSong>();

        [NotMapped]
        public int TotalTracks => Songs == null ? 0 : Songs.Count;

    }
}
