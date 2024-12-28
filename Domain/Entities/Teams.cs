using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;
[Table("Tables")]
public class Team
{
   public int Id { get; set; } 
   [Required,MaxLength(30)]
   public string Name { get; set; }
   public DateTime CreatedDate { get; set; }
   [Required,MaxLength(30)]
   public string Leader { get; set; }
   public int TotalMembers { get; set; }
   public decimal Score { get; set; }
   public Status Status { get; set; } = 0;
   public int HackathonId { get; set; }
   [ForeignKey("HackathonId")]
   public Hackathon Hackathon { get; set; }
   public List<Participant> Participants { get; set; }=[];
}
