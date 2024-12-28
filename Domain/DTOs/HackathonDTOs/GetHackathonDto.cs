using Domain.Entities;

namespace Domain.DTOs.HackathonDTOs;

public record GetHackathonDto:BaseHackathonDto
{
 public int Id { get; set; }
 public List<Team> Teams { get; set; }=[];
}
