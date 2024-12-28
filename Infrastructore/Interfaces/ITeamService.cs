using Domain.DTOs.TeamDTOs;
using Domain.Entities;
using Infrastructore.Responses;

namespace Infrastructore.Interfaces;

public interface ITeamService
{
   // Task<Response<List<GetTeamDto>>> GetAllTeams();
    Task<Response<Team>> GetTeamById(int id);
    Task<Response<string>> CreateTeam(AddTeamDto team);
    Task<Response<string>> UpdateTeam(UpdateTeamDto team);
    Task<Response<string>> DeleteTeam(int id);
}


