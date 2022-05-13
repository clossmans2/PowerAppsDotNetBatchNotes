using System.Text.Json;

namespace FriendMusic
{
    public class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToUpper();
        }
    }
}
