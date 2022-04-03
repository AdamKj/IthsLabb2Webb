using System.Text.Json.Serialization;

namespace IthsLabb2Webb.Shared.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CourseLength { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    [JsonIgnore]
    public List<User> Users { get; set; } = new();
}