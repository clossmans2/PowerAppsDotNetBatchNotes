using System.Text.Json.Serialization;

namespace FriendMusic.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Artist { get; set; } = String.Empty;
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan Length { get; set; }
        public string AlbumTitle { get; set; } = String.Empty;
        
        //public ICollection<Person>? FavoritedByPeople { get; set; }
    }
}
