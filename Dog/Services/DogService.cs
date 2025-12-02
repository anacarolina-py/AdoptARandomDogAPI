using Dogs.API.DTO;
using Dogs.Models;
using System.Text.Json;

public class DogService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options =
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    private readonly DogRepository _dogRepository;

    public DogService(HttpClient client, DogRepository dogRepository)
    {
        _client = client;
        _dogRepository = dogRepository;
    }

    public async Task<DogImage?> GetRandomDogImageAsync()
    {
        var response = await _client.GetAsync("https://dog.ceo/api/breeds/image/random");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var dogResponse = JsonSerializer.Deserialize<DogImageApi>(content, _options);

        if (dogResponse == null)
            return null;

        return new DogImage
        {
            Message = dogResponse.Message,
            Status = dogResponse.Status
        };
    }

    public async Task<List<DogResponseDTO>> GetAllDogsAsync()
    {
        return await _dogRepository.GetAllDogsAsync();
    }

    public async Task<DogResponseDTO?> GetDogByIdAsync(int id)
    {
        return await _dogRepository.GetDogByIdAsync(id);
    }

    public async Task AddDogAsync(Dog dog)
    {
        await _dogRepository.AddDogAsync(dog);
    }

    public async Task DeleteDogAsync(int id)
    {
        await _dogRepository.DeleteDogAsync(id);
    }

    public async Task UpdateDogAsync(int id, DogUpdateDTO dog)
    {
        await _dogRepository.UpdateDogAsync(id, dog);
    }

    public async Task<List<TutorRequestDTO>> GetAllTutorsAsync()
    {
        return await _dogRepository.GetAllTutorsAsync();
    }
    public async Task AddTutorAsync(Tutor tutor)
    {
        await _dogRepository.AddTutorAsync(tutor);
    }
}
