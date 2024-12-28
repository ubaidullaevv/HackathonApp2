namespace Domain.DTOs;

public record BaseHackathonDto
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string? Theme { get; set; }
    public string Location { get; set; }
    public int MaxTeams { get; set; }
    public string? Description { get; set; }
}
