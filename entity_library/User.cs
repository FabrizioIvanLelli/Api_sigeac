namespace entity_library;

using System.ComponentModel.DataAnnotations;
using BCrypt.Net;

public class User : Person
{
    private string email = "";
    private string passwordHash = "";
    private string username = "";

    [Required]
    [EmailAddress]
    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    [Required]
    public string PasswordHash
    {
        get { return passwordHash; }
        set { passwordHash = value; }
    }

    [Required]
    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    public static string HashPassword(string password)
    {
        return BCrypt.HashPassword(password);
    }
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Verify(password, hashedPassword);
    }
}


