namespace FriendMusic.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime Birthday { get; set; } = new DateTime();

        public Song? FavoriteSong { get; set; }
    }
}
