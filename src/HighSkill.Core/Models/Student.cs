using System;
using System.Collections.Generic;

namespace HighSkill.Core.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginDate { get; set; }
    public bool IsActive { get; set; } = true;
    
    // Навигационное свойство для связи с Enrollment
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}