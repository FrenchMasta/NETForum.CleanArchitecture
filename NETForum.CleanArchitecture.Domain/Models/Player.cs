using Domain.Entity;
using Domain.Enums;

namespace Domain.Models;

// Sealed = Prevents classes deriving from Player
public sealed class Player : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ShirtNumber { get; set; }
    public PlayerPosition PlayerPosition { get; set; }
}