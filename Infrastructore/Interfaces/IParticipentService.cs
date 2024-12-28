using Domain.DTOs.ParticipentDTOs;
using Domain.Entities;
using Infrastructore.Responses;

namespace Infrastructore.Interfaces;

public interface IParticipentService
{
    Task<Response<List<GetParticipentDto>>> GetAllParticipents();
    Task<Response<Participant>> GetParticipentById(int id);
    Task<Response<string>> CreateParticipent(AddParticipentDto participent);
    Task<Response<string>> UpdateParticipent(UpdateParticipentDto participent);
    Task<Response<string>> DeleteParticipent(int id);
}
