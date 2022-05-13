using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FriendMusic.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Display(Name = "Song Name")]
        //[StringLength(50)]
        public string Title { get; set; } = String.Empty;

        [Required]
        //[Display(Name = "Sound Specialist Esquire The Third")]
        public string Artist { get; set; } = String.Empty;
        
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan Length { get; set; }
        public string AlbumTitle { get; set; } = String.Empty;

        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
