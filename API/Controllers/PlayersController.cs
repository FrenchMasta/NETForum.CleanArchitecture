using API.Controllers.Common;
using Application.DTOs;
using Application.Interfaces.Services;
using Application.Queries.Player.GetPlayerDtoByName;
using Application.Queries.Player.GetPlayerDtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

public class PlayersController : ApiControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    #region CQRS API - With MediatR Pattern

    [HttpGet("CQRS/GetAll")]
    [SwaggerOperation(
        Summary = "Get all players (using MediatR)",
        Description = "Returns a list of all players."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the list of all players.", typeof(List<PlayerDto>))]
    public async Task<ActionResult<List<PlayerDto>>> GetAllUsingMediatr()
    {
        return await Mediatr.Send(new GetPlayerDtosQuery());
    }

    [HttpGet("CQRS/team/{teamName}")]
    [SwaggerOperation(
        Summary = "Get players by team name (using MediatR)",
        Description = "Returns a list of players belonging to a specific team based on the provided team name."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the list of players for the specified team.", typeof(List<PlayerDto>))]
    public async Task<ActionResult<List<PlayerDto>>> GetByTeamUsingMediatr([FromRoute] string teamName)
    {
        return await Mediatr.Send(new GetPlayerDtosByNameQuery { TeamName = teamName });
    }

    [HttpGet("CQRS/{id}")]
    [SwaggerOperation(
        Summary = "Get a player by ID  (using MediatR)",
        Description = "Returns a player with the specified unique identifier."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the player with the specified ID.", typeof(PlayerDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Player with the specified ID was not found.")]
    public async Task<ActionResult<PlayerDto>> GetByIdUsingMediatr([FromRoute] long id)
    {
        return await Mediatr.Send(new GetPlayerDtoByIdQuery { Id = id });
    }

    #endregion

    #region Conventional-ish API

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all players",
        Description = "Returns a list of all players."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the list of all players.", typeof(List<PlayerDto>))]
    public ActionResult<List<PlayerDto>> GetAll()
    {
        try
        {
            var result = _playerService.GetAllPlayers();

            if (!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("team/{teamName}")]
    [SwaggerOperation(
        Summary = "Get players by team name",
        Description = "Returns a list of players belonging to a specific team based on the provided team name."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the list of players for the specified team.", typeof(List<PlayerDto>))]
    public ActionResult<List<PlayerDto>> GetByTeam([FromRoute] string teamName)
    {
        try
        {
            var result = _playerService.GetAllPlayersForTeam(teamName);

            if (!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a player by ID",
        Description = "Returns a player with the specified unique identifier."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the player with the specified ID.", typeof(PlayerDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Player with the specified ID was not found.")]
    public ActionResult<PlayerDto> GetById([FromRoute] long id)
    {
        try
        {
            var result = _playerService.GetPlayerById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    #endregion
}