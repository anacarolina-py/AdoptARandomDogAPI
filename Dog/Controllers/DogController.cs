using Dogs.API.DTO;
using Dogs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DogService _dogService;

        public DogController(DogService dogService)
        {
            _dogService = dogService;
        }


        [HttpGet("getall")]
        public async Task<ActionResult<List<DogResponseDTO>>> GetAllDogs()
        {
            try
            {
                var dogs = await _dogService.GetAllDogsAsync();
                return Ok(dogs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex.Message}");
            }

        }

        [HttpGet("get/{id}")]

        public async Task<ActionResult<DogResponseDTO>> GetDogById(int id)
        {
            try
            {
                var dog = await _dogService.GetDogByIdAsync(id);
                if (dog == null)
                {
                    return NotFound();
                }
                return Ok(dog);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex.Message}");
            }
        }


        [HttpPost("add")]
        public async Task<ActionResult> AddDog(DogRequestDTO dog)
        {
            try
            {
                var dogImage = await _dogService.GetRandomDogImageAsync();

                var newDog = new Dog(dog.Name, dogImage);

                await _dogService.AddDogAsync(newDog);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteDog(int id)
        {
            try
            {
                await _dogService.DeleteDogAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateDog(int id, DogUpdateDTO dog)
        {
            try
            {
                await _dogService.UpdateDogAsync(id, dog);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("addtutor/{dogId}")]
        public async Task<ActionResult> AddTutor(int dogId, TutorRequestDTO tutor)
        {
            try
            {
                var newTutor = new Tutor(tutor.Name, tutor.Phone, tutor.Email, dogId);
                await _dogService.AddTutorAsync(newTutor);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("tutors")]
        public async Task<ActionResult<List<TutorRequestDTO>>> GetAllTutors()
        {
            try
            {
                var tutors = await _dogService.GetAllTutorsAsync();
                return Ok(tutors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}