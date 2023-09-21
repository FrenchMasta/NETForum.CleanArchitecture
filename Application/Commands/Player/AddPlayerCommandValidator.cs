using Domain.Enums;
using Domain.Helpers;
using FluentValidation;

namespace Application.Commands.Player;

public class AddPlayerCommandValidator : AbstractValidator<AddPlayerCommand>
{
    public AddPlayerCommandValidator()
    {
        RuleFor(x => x.PlayerDto.FirstName.Trim())
            .NotEmpty().WithMessage("We need a name, sir/madam")
            .MinimumLength(2).WithMessage("Are you a letter in the alphabet?")
            .MaximumLength(255).WithMessage("Who named you?");

        RuleFor(x => x.PlayerDto.LastName.Trim())
            .NotEmpty().WithMessage("We need a name, sir/madam")
            .MinimumLength(2).WithMessage("Are you a letter in the alphabet?")
            .MaximumLength(255).WithMessage("Who named you?");

        RuleFor(x => x.PlayerDto.ShirtNumber)
            .GreaterThan(0).WithMessage("Would be cool but NO!");

        RuleFor(x => x.PlayerDto.PlayerPosition)
            .NotEmpty().WithMessage("What will this player do if they have no position?")
            .Must(BeAValidPlayerPosition).WithMessage("We've not heard of this position. Calm down Pep Guardiola");
    }

    private static bool BeAValidPlayerPosition(string playerPosition)
    {
        var enumDescriptions = Enum.GetValues(typeof(PlayerPosition))
            .Cast<PlayerPosition>()
            .Select(playerPositionEnumValue => EnumHelper.GetEnumDescription(playerPositionEnumValue))
            .ToList();

        return enumDescriptions.Any(enumDescription => enumDescription.Equals(playerPosition, StringComparison.InvariantCultureIgnoreCase));
    }
}