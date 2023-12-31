﻿using FluentValidation;
using System.Linq.Expressions;

namespace Application.Queries.Player.GetPlayersByName;

public class GetPlayersByNameQueryValidator : AbstractValidator<GetPlayersByNameQuery>
{
    private const string ThatKakTeamWeAllDoNotLike = "LIVERPOOL";
    private const string NoIssuesEvenAfterChargesAre115 = "MANCHESTER CITY";

    public GetPlayersByNameQueryValidator()
    {
        Expression<Func<GetPlayersByNameQuery, string>> trimmedTeamName = x => x.TeamName.Trim();

        RuleFor(trimmedTeamName)
            .NotEmpty()
            .WithMessage("No team name provided, what do you expect me to retrieve?");

        RuleFor(trimmedTeamName)
            .Must(BeAnyoneButLiverpool)
            .WithMessage("Who hurt you?");

        RuleFor(trimmedTeamName)
            .Must(BeAnyoneButManCity)
            .WithMessage("Nice try noisy neighbour");
    }

    private static bool BeAnyoneButLiverpool(string teamName)
    {
        return !string.Equals(teamName, ThatKakTeamWeAllDoNotLike, StringComparison.InvariantCultureIgnoreCase);
    }

    private static bool BeAnyoneButManCity(string teamName)
    {
        return !string.Equals(teamName, NoIssuesEvenAfterChargesAre115, StringComparison.InvariantCultureIgnoreCase);
    }
}