using FriendMusic.Data;

namespace FriendMusic.Models
{
    public class LikedPlaylist
    {
        public Guid Id { get; set; }
        
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public LikedPlaylist()
        {

        }

        public LikedPlaylist(FMContext ctx, int playlistId, int personId)
        {
            this.PlaylistId = playlistId;
            this.PersonId = personId;
            this.Person = ctx.People.Find(personId) ?? new Person();
            this.Playlist = ctx.Playlists.Find(playlistId) ?? new Playlist();
        }
    }
}
