using Domain.Entities;

namespace Domain.DTOs.TeamDTOs;

public record GetTeamDto:BaseTeamDto
{
    public int Id { get; set; }
    public List<Participant> Participants { get; set; }=[];
}
