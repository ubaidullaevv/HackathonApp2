using System.Net;
using Domain.DTOs;
using Domain.DTOs.HackathonDTOs;
using Domain.DTOs.ParticipentDTOs;
using Domain.DTOs.TeamDTOs;
using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Services;

public class HackathonService(DataContext context) : IHackathonService
{
    public async Task<Response<string>> CreateHackathon(AddHackathonDto hackathon)
    {
        
        var hackaton = new Hackathon()
        {
        Date=hackathon.Date,
        Description=hackathon.Description,
        Location=hackathon.Location,
        Name=hackathon.Name,
        MaxTeams=hackathon.MaxTeams,
        Theme=hackathon.Theme
        };
        await context.Hackathons.AddAsync(hackaton);
        var res=await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Hackathon not created!")
        : new Response<string>("Hackathon created successfully!");
    }

    public async Task<Response<string>> DeleteHackathon(int id)
    {
        var exist= await context.Hackathons.FirstOrDefaultAsync(x=>x.Id==id);
        if(exist==null)
        {
            return new Response<string>(HttpStatusCode.NotFound,"Hackathon not found!");
        }
         context.Hackathons.Remove(exist);
         var res=await context.SaveChangesAsync();
         return res == 0
         ? new Response<string>(HttpStatusCode.InternalServerError,"Hackathon not deleted!")
         : new Response<string>("Hackathon deleted successfully!");
    }

    // public async Task<Response<List<GetHackathonDto>>> GetAllHackathons()
    // {
    //     var hackaton=await context.Hackathons.Include(t=>t.Teams).ToListAsync();
    //     var res =  hackaton.Select(x=> new GetHackathonDto()
    //     {
    //         Id=x.Id,
    //         Name=x.Name,
    //         Location=x.Location,
    //         Date=x.Date,
    //         Description=x.Description,
    //         Theme=x.Theme,
    //         MaxTeams=x.MaxTeams,
    //         Teams=x.Teams.Select(t=>new GetTeamDto()
    //         {
    //             Id=t.Id,
    //             Name=t.Name,
    //             CreatedDate=t.CreatedDate,
    //             Leader=t.Leader,
    //             Score=t.Score,
    //             TotalMembers=t.TotalMembers,
    //             HackathonId=t.HackathonId
                
    //         }).ToList()
    //     }).ToList();
    //     return new Response<List<GetHackathonDto>>(res);
    // }

    public async Task<Response<Hackathon>> GetHackathonById(int id)
    {
        var hackathon=await context.Hackathons.Include(t=>t.Teams).FirstOrDefaultAsync(x=>x.Id==id);
        if(hackathon==null)
        {
            return new Response<Hackathon>(HttpStatusCode.NotFound,"Hackathon not found!");
        }
        return new Response<Hackathon>(hackathon);
    }

    public async Task<Response<string>> UpdateHackathon(UpdateHackathonDto hackathon)
    {
        var exist=await context.Hackathons.FirstOrDefaultAsync(x=>x.Id==hackathon.Id);
        if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"Hackathon not found!");
        exist.Date=hackathon.Date;
        exist.Description=hackathon.Description;
        exist.Location=hackathon.Location;
        exist.Name=hackathon.Name;
        exist.MaxTeams=hackathon.MaxTeams;
        exist.Theme=hackathon.Theme;
        var res=await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Hackathon not updated!")
         : new Response<string>("Hackathon updated successfully!");
    }
}
