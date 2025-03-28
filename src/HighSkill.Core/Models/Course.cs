namespace HighSkill.Core.Models;
public class Course
{
    public Course()
    {
    Title = string.Empty;
    Description = string.Empty;
    }
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}