using Dogs.Models;

namespace Dogs.API.DTO
{
    public class DogRequestDTO
    {
        public string Name { get; set; }
        public DogImage? ImageUrl { get; set; }
    }
}
