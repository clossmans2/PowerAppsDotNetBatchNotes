using FriendMusic.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendMusic.Models
{
    public class PlaylistSong
    {
        public Guid Id { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }


        public DateTime AddedDate { get; set; }
    }
}
