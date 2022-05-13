using FriendMusic.Data;

namespace FriendMusic.Models
{
    public class LikedPlaylist
    {
        public Guid Id { get; set; }
        public int PlaylistId { get; set; }
        public int PersonId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
