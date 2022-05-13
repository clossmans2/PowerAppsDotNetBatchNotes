using FriendMusic.Models;

namespace FriendMusic.DTO
{
    public class PlaylistDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Person Owner { get; set; }
        public List<Song> Songs { get; set; }
        public List<Person> LikedBy { get; set; }
        public int TotalTracks => Songs == null ? 0 : Songs.Count;
    }
}
