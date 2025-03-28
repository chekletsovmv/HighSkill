using System;
using System.Collections.Generic;

namespace HighSkill.Core.Models;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    public DateTime? CompletionDate { get; set; }
    public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;
    
    // Навигационные свойства
    public Student? Student { get; set; }
    public Course? Course { get; set; }
}

public enum EnrollmentStatus
{
    Active = 1,
    Completed = 2,
    Cancelled = 3
}