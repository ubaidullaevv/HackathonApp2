using System.Net;
using Domain.DTOs;
using Domain.DTOs.TeamDTOs;
using Domain.DTOs.ParticipentDTOs;
using Domain.DTOs.TeamDTOs;
using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Services;

public class TeamService(DataContext context) : ITeamService
{
    public async Task<Response<string>> CreateTeam(AddTeamDto team)
    {
        
        var hackaton = new Team()
        {
        Name=team.Name,
        CreatedDate=team.CreatedDate,
        Leader=team.Leader,
        Score=team.Score,
        HackathonId=team.HackathonId,
        };
        await context.Teams.AddAsync(hackaton);
        var res=await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Team not created!")
        : new Response<string>("Team created successfully!");
    }

    public async Task<Response<string>> DeleteTeam(int id)
    {
        var exist= await context.Teams.FirstOrDefaultAsync(x=>x.Id==id);
        if(exist==null)
        {
            return new Response<string>(HttpStatusCode.NotFound,"Team not found!");
        }
         context.Teams.Remove(exist);
         var res=await context.SaveChangesAsync();
         return res == 0
         ? new Response<string>(HttpStatusCode.InternalServerError,"Team not deleted!")
         : new Response<string>("Team deleted successfully!");
    }

    // public async Task<Response<List<GetTeamDto>>> GetAllTeams()
    // {
    //     var team=await context.Teams.Include(t=>t.Participants).ToListAsync();
    //     var res = team.Select(x=> new GetTeamDto()
    //     {
    //         Id=x.Id,
    //         Name=x.Name,
    //         HackathonId=x.HackathonId,
    //         Leader=x.Leader,
    //         Score=x.Score,
           
    //         CreatedDate=x.CreatedDate,
    //         Participants=x.Participants.Select(t=>new GetParticipentDto()
    //         {
    //             Id=t.Id,
    //             Name=t.Name,
    //             Email=t.Email,
    //             ExperienceLevel=t.ExperienceLevel,
    //             JoinDate=t.JoinDate,
    //             PhoneNumber=t.PhoneNumber,
    //             Role=t.Role,
    //             Skills=t.Skills
    //         }).ToList();
    //     }).ToList();
    //     return new Response<List<GetTeamDto>>(res);
    // }

    public async Task<Response<Team>> GetTeamById(int id)
    {
        var Team=await context.Teams.Include(t=>t.Participants).FirstOrDefaultAsync(x=>x.Id==id);
        if(Team==null)
        {
            return new Response<Team>(HttpStatusCode.NotFound,"Team not found!");
        }
        return new Response<Team>(Team);
    }

    public async Task<Response<string>> UpdateTeam(UpdateTeamDto team)
    {
        var exist=await context.Teams.FirstOrDefaultAsync(x=>x.Id==team.Id);
        if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"Team not found!");
        exist.CreatedDate=team.CreatedDate;
        exist.HackathonId=team.HackathonId;
        exist.Leader=team.Leader;
        exist.Name=team.Name;
        exist.Score=team.Score;
        var res=await context.SaveChangesAsync();
        return res == 0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Team not updated!")
         : new Response<string>("Team updated successfully!");
    }
}
