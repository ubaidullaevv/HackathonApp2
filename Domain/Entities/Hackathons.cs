using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("Hackathons")]
public class Hackathon
{
    public int Id { get; set; }
    [Required,MaxLength(30)]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    [MaxLength(100)]
    public string? Theme { get; set; }
    [Required,MaxLength(50)]
    public string Location { get; set; }
    public int MaxTeams { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    public List<Team> Teams { get; set; }=[];
}
