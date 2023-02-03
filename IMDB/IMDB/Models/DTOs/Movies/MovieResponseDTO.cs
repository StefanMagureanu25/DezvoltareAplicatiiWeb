namespace IMDB.Models.DTOs.Movies
{
    public class MovieResponseDTO
    {
        public Guid MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string? MovieDescription { get; set; }
        public Director? Director { get; set; }
        public DateTime? ReleaseDate { get; set; }

    }
}
