using API.Controllers.Common;
using Application.Commands.Player;
using Application.DTOs;
using Application.Queries.Player.GetPlayerById;
using Application.Queries.Player.GetPlayers;
using Application.Queries.Player.GetPlayersByName;
using Application.ServiceResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.CQRS;

public class NewPlayersController : ApiControllerBase
{
    [HttpGet("CQRS/GetAll")]
    [SwaggerOperation(
        Summary = "Get all players (using MediatR)",
        Description = "Returns a list of all players."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the list of all players.", typeof(List<PlayerDto>))]
    public async Task<ActionResult<List<PlayerDto>>> GetAllUsingMediatr()
    {
        return await Mediatr.Send(new GetPlayersQuery());
    }

    [HttpGet("CQRS/team/{teamName}")]
    [SwaggerOperation(
        Summary = "Get players by team name (using MediatR)",
        Description = "Returns a list of players belonging to a specific team based on the provided team name."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the list of players for the specified team.", typeof(List<PlayerDto>))]
    public async Task<ActionResult<List<PlayerDto>>> GetByTeamUsingMediatr([FromRoute] string teamName)
    {
        return await Mediatr.Send(new GetPlayersByNameQuery(teamName));
    }

    [HttpGet("CQRS/{id}")]
    [SwaggerOperation(
        Summary = "Get a player by ID (using MediatR)",
        Description = "Returns a player with the specified unique identifier."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the player with the specified ID.", typeof(PlayerDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Player with the specified ID was not found.")]
    public async Task<ActionResult<PlayerDto>> GetByIdUsingMediatr([FromRoute] long id)
    {
        return await Mediatr.Send(new GetPlayerByIdQuery(id));
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Add a new player (using MediatR)",
        Description = "Add a new player that is a free-agent"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully created a new player.", typeof(int))]
    public async Task<ActionResult<Created>> CreatePlayer([FromBody] PlayerDto playerDto)
    {
        return await Mediatr.Send(new AddPlayerCommand(playerDto));
    }
}