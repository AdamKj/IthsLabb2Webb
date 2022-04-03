using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IthsLabb2Webb.Shared.Models;

[Owned]
public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    [MaxLength(5, ErrorMessage = "Zip Code can't be longer than 5 characters.")]
    public string Zip { get; set; } = string.Empty;
}