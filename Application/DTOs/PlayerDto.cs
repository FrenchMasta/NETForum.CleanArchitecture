namespace Application.DTOs;

// TODO: Show what a "sealed" class (Player) will do
//public sealed class PlayerDto : Player
//{
//}

public class PlayerDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ShirtNumber { get; set; }
    public string PlayerPosition { get; set; }
}