using Domain.DTOs;
using Domain.DTOs.HackathonDTOs;
using Domain.Entities;
using Infrastructore.Responses;

namespace Infrastructore.Interfaces;

public interface IHackathonService
{
   // Task<Response<List<GetHackathonDto>>> GetAllHackathons();
    Task<Response<Hackathon>> GetHackathonById(int id);
    Task<Response<string>> CreateHackathon(AddHackathonDto hackathon);
    Task<Response<string>> UpdateHackathon(UpdateHackathonDto hackathon);
    Task<Response<string>> DeleteHackathon(int id);
}
