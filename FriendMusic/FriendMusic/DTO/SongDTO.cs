using System.Text.Json.Serialization;

namespace FriendMusic.DTO
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }

        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan Length { get; set; }
        public string? AlbumTitle { get; set; }
    }
}
