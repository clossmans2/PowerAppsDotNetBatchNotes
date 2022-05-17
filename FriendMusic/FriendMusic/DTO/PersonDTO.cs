using FriendMusic.Models;

namespace FriendMusic.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public SongDTO? FavoriteSong { get; set; }
        public List<PlaylistDTO>? LikedPlaylists { get; set; }
        public ICollection<PlaylistDTO>? OwnedPlaylists { get; set; }
    }
}
