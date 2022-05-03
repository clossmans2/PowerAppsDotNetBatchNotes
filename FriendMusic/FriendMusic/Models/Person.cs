using System.Text.Json.Serialization;

namespace FriendMusic.Models
{
    public class Person
    {
        public int Id { get; set; }
        //[JsonPropertyName("First")]
        public string FirstName { get; set; } = String.Empty;
        //[JsonPropertyName("Last")]
        public string LastName { get; set; } = String.Empty;
        //[JsonPropertyName("BDay")]
        public DateTime Birthday { get; set; } = new DateTime();

        public Song? FavoriteSong { get; set; }
    }
}
