using Api_sigeac.DTOs;
using dao_library.entity_framework;
using entity_library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_sigeac.Controllers;

[Authorize]
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

    [AllowAnonymous]
    [HttpPost]
    public ActionResult CreateUser(User user)
    {
        var createdUser = new User
        {
            Email = user.Email,
            PasswordHash = entity_library.User.HashPassword(user.PasswordHash),
            Username = user.Username,
            Dni = user.Dni,
            Name = user.Name,
            Age = user.Age
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

        user.PasswordHash = entity_library.User.HashPassword(user.PasswordHash);

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
    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO loginDTO, [FromServices] IConfiguration config)
    {
        var user = _userDAO.GetUserEmail(loginDTO.Email);

        if (user == null)
        {
            return Unauthorized("Credenciales inválidas.");
        }

        bool isPasswordValid = entity_library.User.VerifyPassword(loginDTO.Password, user.PasswordHash);

        if (!isPasswordValid)
        {
            return Unauthorized("Credenciales inválidas.");
        }

        var jwtKey = config["Jwt:Key"];
        var keyBytes = Encoding.UTF8.GetBytes(jwtKey!);

        var claims = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Username)
        });

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(tokenConfig);

        return Ok(new { Token = token });
    }
}
