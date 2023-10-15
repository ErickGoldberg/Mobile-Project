using Microsoft.AspNetCore.Mvc;
using MongoConnection.Repository;
using System.Linq.Expressions;
using WebApi.Data;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly CrudRepository<Workout> _repository;

        public WorkoutController(CrudRepository<Workout> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult InsertWorkout(Workout workout)
        {
            try
            {
                _repository.InsertOne(workout);
                return Ok("Workout inserted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkoutById(string id)
        {
            try
            {
                var workout = _repository.FindById(x => x.Id == id);
                if (workout == null)
                    return NotFound("Workout not found.");
                
                return Ok(workout);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var workouts = _repository.GetAll();
                return Ok(workouts);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateObj(string id, Workout workout)
        {
            try
            {
                Expression<Func<Workout, bool>> filter = x => x.Id == id;
                var existingWorkout = _repository.FindBy(filter);
                if (existingWorkout == null)
                {
                    return NotFound("Workout not found.");
                }

                _repository.UpdateObj(filter, workout);
                return Ok("Workout updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWorkout(string id)
        {
            try
            {
                Expression<Func<Workout, bool>> filter = x => x.Id == id;
                var existingWorkout = _repository.FindBy(filter);
                if (existingWorkout == null)
                {
                    return NotFound("Workout not found.");
                }

                _repository.RemoveObj(filter);
                return Ok("Workout deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
