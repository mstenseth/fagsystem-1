namespace fagsystem_1.Dtos;

public class NatureIncidentDto
{
    public NatureIncidentDto()
    {
        ClosedRoads = new List<ClosedRoadDto>();
    }
    public int Id {get;set;}
    public DateTime Created {get;set;}
    public DateTime Updated {get;set;}

    public IEnumerable<ClosedRoadDto> ClosedRoads {get;set;}

}