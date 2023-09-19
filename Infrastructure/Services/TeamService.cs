using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;

namespace Infrastructure.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public TeamService(ITeamRepository teamRepository, IMapper mapper)
    {
        _teamRepository = teamRepository;
        _mapper = mapper;
    }

    public List<TeamDto> GetAllTeams()
    {
        var teams = _teamRepository.GetAll();
        return _mapper.Map<List<TeamDto>>(teams);
    }

    public TeamDto? GetByTeamName(string teamName)
    {
        var team = _teamRepository.GetByTeamName(teamName);
        return team == null ? null : _mapper.Map<TeamDto>(team);
    }

    public TeamDto? GetByTeamId(long id)
    {
        var team = _teamRepository.GetById(id);
        return team == null ? null : _mapper.Map<TeamDto>(team);
    }
}