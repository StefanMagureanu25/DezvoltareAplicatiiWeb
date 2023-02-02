namespace IMDB.Models.DTOs.Directors
{
    public class DirectorResponseDTO
    {
        public Guid DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
