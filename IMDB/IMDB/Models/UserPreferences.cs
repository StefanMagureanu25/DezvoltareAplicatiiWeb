using IMDB.Models.Base;
using System.Text.Json.Serialization;

namespace IMDB.Models
{
    public class UserPreferences : BaseEntity
    {
        [JsonIgnore]
        public Guid UserPreferencesId { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }

        //remember when was last update of these preferences
        public DateTime LastUpdatedPreferences { get; set; }

        //dark mode / light mode
        public string? ColorPreference { get; set; }

        //self-explanatory
        public int FontSize { get; set; }

        public string? Language { get; set; }

        //Indicates if user wants to receive notifications from me
        public bool SendNotifications { get; set; }

        //Indicates the preferred movie genre for recommendations of directors
        //from that particular area
        public string? PreferredMovieGenre { get; set; }
    }
}
