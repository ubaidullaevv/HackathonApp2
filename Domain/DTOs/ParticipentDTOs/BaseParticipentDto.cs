using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.DTOs.ParticipentDTOs;

public record BaseParticipentDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; }
    public string? Role { get; set; }
    public List<string>? Skills { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public DateTime JoinDate { get; set; } 
    public int TeamId { get; set; }
}
