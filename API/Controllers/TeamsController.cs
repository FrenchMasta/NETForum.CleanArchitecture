using Application.Interfaces.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all teams",
            Description = "Returns a list of all teams."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the list of all teams.", typeof(List<TeamDto>))]
        public ActionResult<List<TeamDto>> GetAllTeams()
        {
            try
            {
                var teams = _teamService.GetAllTeams();

                if (!teams.Any())
                {
                    return NoContent();
                }

                return Ok(teams);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("team/{teamName}")]
        [SwaggerOperation(
            Summary = "Get a team by name",
            Description = "Returns a team with the specified name."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the team with the specified name.", typeof(TeamDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Team with the specified name was not found.")]
        public ActionResult<TeamDto> GetByTeamName([FromRoute] string teamName)
        {
            try
            {
                var team = _teamService.GetByTeamName(teamName);

                if (team == null)
                {
                    return NotFound();
                }

                return Ok(team);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a team by ID",
            Description = "Returns a team with the specified unique identifier."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the team with the specified ID.", typeof(TeamDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Team with the specified ID was not found.")]
        public ActionResult<TeamDto> GetByTeamId([FromRoute] long id)
        {
            try
            {
                var team = _teamService.GetByTeamId(id);

                if (team == null)
                {
                    return NotFound();
                }

                return Ok(team);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
