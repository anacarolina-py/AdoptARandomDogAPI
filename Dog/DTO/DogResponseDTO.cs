using Dogs.Models;

namespace Dogs.API.DTO
{
    public class DogResponseDTO
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }
        public bool Adopted { get; set; }
    }
}
