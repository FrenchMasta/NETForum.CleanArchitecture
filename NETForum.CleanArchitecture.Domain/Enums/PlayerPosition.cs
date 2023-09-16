using System.ComponentModel;

namespace Domain.Enums;

public enum PlayerPosition
{
    [Description("Goal Keeper")]
    GoalKeeper = 1,
    [Description("Defender")]
    Defender = 2,
    [Description("Midfielder")]
    Midfielder = 3,
    [Description("Forward")]
    Forward = 4
}