using Domain.DTOs;
using Domain.DTOs.HackathonDTOs;
using Domain.Entities;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HackathonController(IHackathonService service):ControllerBase
{
    public async Task<Response<string>> Create(AddHackathonDto hackathon) => await service.CreateHackathon(hackathon);
    public async Task<Response<List<GetHackathonDto>>> GetAll() => await service.GetAllHackathons();
    public async Task<Response<Hackathon>> GetById(int id) => await service.GetHackathonById(id);
    public async Task<Response<string>> Update(UpdateHackathonDto hackathon) => await service.UpdateHackathon(hackathon);
    public async Task<Response<string>> Delete(int id) => await service.DeleteHackathon(id);
}
