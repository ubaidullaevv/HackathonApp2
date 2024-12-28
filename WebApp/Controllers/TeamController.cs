using Domain.DTOs;
using Domain.DTOs.TeamDTOs;
using Domain.Entities;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController(ITeamService service):ControllerBase
{
    public async Task<Response<string>> Create(AddTeamDto team) => await service.CreateTeam(team);
    public async Task<Response<List<GetTeamDto>>> GetAll() => await service.GetAllTeams();
    public async Task<Response<Team>> GetById(int id) => await service.GetTeamById(id);
    public async Task<Response<string>> Update(UpdateTeamDto team) => await service.UpdateTeam(team);
    public async Task<Response<string>> Delete(int id) => await service.DeleteTeam(id);
}
