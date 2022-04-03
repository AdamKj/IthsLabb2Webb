using System.ComponentModel.DataAnnotations;

namespace IthsLabb2Webb.Shared.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    [MaxLength(10, ErrorMessage = "Number can't be longer than 10 characters.")] 
    public string Phone { get; set; } = string.Empty;

    public Address Address { get; set; } = new();
    public List<Course> Courses { get; set; } = new();
    public string Role { get; set; } = "Customer";
}