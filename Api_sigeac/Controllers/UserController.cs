using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

using entity_library;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly UserDAO _userDAO;

    public UserController(ILogger<UserController> logger, UserDAO userDAO)
    {
        _logger = logger;
        _userDAO = userDAO;
    }

    [HttpGet]
    public IActionResult Get(string email)
    {
        try
        {
            var user = _userDAO.GetUserEmail(email);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving user with email {UserEmail}", email);
            return StatusCode(500, "An error occurred with the server.");
        }
    }

    [HttpPost]
    public ActionResult CreateUser(User user)
    {
        var createdUser = new User
        {
            Email = user.Email,
            PasswordHash = entity_library.User.HashPassword(user.PasswordHash),
            Username = user.Username
        };

        _userDAO.SaveUser(createdUser);

        return Created($"/user/{createdUser.Id}", createdUser);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, User user)
    {
        User? existingUser = _userDAO.GetUserById(id);

        if (existingUser == null)
        {
            return NotFound();
        }

        user.Id = id;

        _userDAO.UpdateUser(user);

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            bool deleted = _userDAO.DeleteUserById(id);

            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user with ID {UserId}", id);
            return StatusCode(500, "An error occurred while deleting the user.");
        }
    }
}
