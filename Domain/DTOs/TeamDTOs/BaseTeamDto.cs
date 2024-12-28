namespace Domain.DTOs.TeamDTOs;

public record BaseTeamDto
{
   public string Name { get; set; }
   public DateTime CreatedDate { get; set; }
   public string Leader { get; set; }
   public int TotalMembers { get; set; }
   public decimal Score { get; set; } 
   public int HackathonId { get; set; }
}
