using System.ComponentModel.DataAnnotations;

namespace IthsLabb2Webb.Shared.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [MaxLength(10, ErrorMessage = "Phone number can't be more than 10 characters.")] 
    public string Phone { get; set; } = string.Empty;
    public Address Address { get; set; } = new();
    public List<Course> Courses { get; set; } = new();
    public string Role { get; set; } = "Customer";
}