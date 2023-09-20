using API.Controllers.Common;
using Application.Commands.Team.TransferPlayerToTeam;
using Application.Exceptions;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ApiControllerBase
    {
        
        public TeamsController(ISender mediator)
        {
            _mediatr = mediator;
        }

        [HttpPut("{id}/transfer/{playerId}")]
        [SwaggerOperation(
            Summary = "Transfer a player to a team",
            Description = "Transfers a specified player from their current team to a specified team"
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully transferred the player")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Team or Player not found")]
        public async Task<ActionResult> TransferPlayer([FromRoute] long id, [FromRoute] long playerId)
        {
            var command = new TransferPlayerToTeamCommand(playerId, id);
            try
            {
                await _mediatr.Send(command);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
