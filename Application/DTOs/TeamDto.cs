namespace Application.DTOs;

public class TeamDto
{
    public TeamDto(long id, string name, List<PlayerDto> playerDtoCollection)
    {
        Id = id;
        Name = name;
        Players = playerDtoCollection;

        SetTeamAlias();
    }

    public long Id { get; }
    public string Name { get; }
    public string KnownAs { get; set; }
    public List<PlayerDto> Players { get; }

    private void SetTeamAlias()
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