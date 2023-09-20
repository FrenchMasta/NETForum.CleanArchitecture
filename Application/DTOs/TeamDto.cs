namespace Application.DTOs;

public class TeamDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string KnownAs { get; set; }
    public List<PlayerDto> Players { get; set; }

    public void SetTeamAlias()
    {
        KnownAs = Name switch
        {
            "Manchester United" => "Red Devils",
            "Arsenal" => "The Gunners",
            "Chelsea" => "The Blues",
            "Liverpool" => "Need to keep this PG13 - Just call them kak",
            _ => Name
        };
    }
}