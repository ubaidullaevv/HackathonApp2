using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;
[Table("Participants")]
public class Participant
{
    public int Id { get; set; }
    [MaxLength(30),Required]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; }
    [MaxLength(50)]
    public string? Role { get; set; }
    public List<string>? Skills { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public DateTime JoinDate { get; set; }
    public int TeamId { get; set; }
    [ForeignKey("TeamId")]
    public Team Team { get; set; }
}
