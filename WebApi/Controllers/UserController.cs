using Microsoft.AspNetCore.Mvc;
using MongoConnection.Repository;
using System;
using System.Linq.Expressions;
using WebApi.Data;
using WebApi.Model; // Certifique-se de importar a classe Model se ainda não o fez

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly CrudRepository<User> _repository;

        public UserController(CrudRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                _repository.InsertOne(user);
                return Ok("User created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public IActionResult AuthenticateUser(User user)
        {
            try
            {
                var userLogin = _repository.FindByLoginAndPassword(user.Login, user.Password);
                if (userLogin == null)
                    return NotFound("Login failed. Invalid credentials.");
                
                return Ok("Login successful.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{login}")] 
        public IActionResult GetUserByLogin(string login) 
        {
            try
            {
                var user = _repository.FindBy(x => x.Login == login); 
                if (user == null)
                    return NotFound("User not found.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _repository.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{login}")] 
        public IActionResult UpdateUser(string login, User user)
        {
            try
            {
                Expression<Func<User, bool>> filter = x => x.Login == login; 
                var existingUser = _repository.FindBy(filter);
                if (existingUser == null)
                    return NotFound("User not found.");
                
                _repository.UpdateObj(filter, user);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{login}")]
        public IActionResult DeleteUser(string login)
        {
            try
            {
                Expression<Func<User, bool>> filter = x => x.Login == login; 
                var existingUser = _repository.FindBy(filter);
                if (existingUser == null)
                    return NotFound("User not found.");

                _repository.RemoveObj(filter);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
