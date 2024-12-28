using Domain.DTOs;
using Domain.DTOs.ParticipentDTOs;
using Domain.Entities;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipentController(IParticipentService service):ControllerBase
{
    public async Task<Response<string>> Create(AddParticipentDto participent) => await service.CreateParticipent(participent);
    public async Task<Response<List<GetParticipentDto>>> GetAll() => await service.GetAllParticipents();
    public async Task<Response<Participant>> GetById(int id) => await service.GetParticipentById(id);
    public async Task<Response<string>> Update(UpdateParticipentDto participent) => await service.UpdateParticipent(participent);
    public async Task<Response<string>> Delete(int id) => await service.DeleteParticipent(id);
}
