using System.Net;
using Domain.DTOs;
using Domain.DTOs;
using Domain.DTOs.ParticipentDTOs;
using Domain.DTOs.TeamDTOs;
using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Services;

public class ParticipantService(DataContext context) : IParticipentService
{
    public async Task<Response<string>> CreateParticipent(AddParticipentDto participent)
    {
            var hackaton = new Participant()
        {
        Email=participent.Email,
        ExperienceLevel=participent.ExperienceLevel,
        JoinDate=participent.JoinDate,
        Name=participent.Name,
        PhoneNumber=participent.PhoneNumber,
        Role=participent.Role,
        Skills=participent.Skills,
        TeamId=participent.TeamId
        };
        await context.Participants.AddAsync(hackaton);
        var res=await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Participant not created!")
        : new Response<string>("Participant created successfully!");  
    }

    public async Task<Response<string>> DeleteParticipent(int id)
    {
        var exist= await context.Participants.FirstOrDefaultAsync(x=>x.Id==id);
        if(exist==null)
        {
            return new Response<string>(HttpStatusCode.NotFound,"Participant not found!");
        }
         context.Participants.Remove(exist);
         var res=await context.SaveChangesAsync();
         return res == 0
         ? new Response<string>(HttpStatusCode.InternalServerError,"Participant not deleted!")
         : new Response<string>("Participant deleted successfully!");
    }

    public async Task<Response<List<GetParticipentDto>>> GetAllParticipents()
    {
        var participant=await context.Participants.ToListAsync();
        var res=  participant.Select(x=> new GetParticipentDto()
        {
            Id=x.Id,
            Name=x.Name,
            Email=x.Email,
            ExperienceLevel=x.ExperienceLevel,
            JoinDate=x.JoinDate,
            PhoneNumber=x.PhoneNumber,
            Role=x.Role, 
            Skills=x.Skills 
        }).ToList();
        return new Response<List<GetParticipentDto>>(res);
    }


    public async Task<Response<Participant>> GetParticipentById(int id)
    {
        var Participant=await context.Participants.FirstOrDefaultAsync(x=>x.Id==id);
        if(Participant==null)
        {
            return new Response<Participant>(HttpStatusCode.NotFound,"Participant not found!");
        }
        return new Response<Participant>(Participant);
    }

    public async Task<Response<string>> UpdateParticipent(UpdateParticipentDto participent)
    {
        var exist=await context.Participants.FirstOrDefaultAsync(x=>x.Id==participent.Id);
        if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"Participant not found!");
        exist.Email=participent.Email;
        exist.ExperienceLevel=participent.ExperienceLevel;
        exist.JoinDate=participent.JoinDate;
        exist.PhoneNumber=participent.PhoneNumber;
        exist.Role=participent.Role;
        exist.Skills=participent.Skills;
        exist.TeamId=participent.TeamId;
        var res=await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Participant not updated!")
         : new Response<string>("Participant updated successfully!");
    }

}





