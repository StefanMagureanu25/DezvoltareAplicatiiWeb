using System.Text.Json.Serialization;

namespace IMDB.Models
{
    public class UserSettings
    {
        [JsonIgnore]
        public Guid UserSettingsId { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }

        //dark mode / light mode
        public string? ColorPreference { get; set; }

        //to be continued from here with different preferences
    }
}
