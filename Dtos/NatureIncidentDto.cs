using fagsystem_1.Domain.Constants;

namespace fagsystem_1.Dtos;

public class NatureIncidentDto
{
    public NatureIncidentDto()
    {
        ClosedRoads = new List<ClosedRoadDto>();
        ImageUris = new List<string>();
    }
    public int Id {get;set;}

    /// <summary>
    /// Skred type
    /// </summary>
    public NatureIncidentType Type {get;set;}

    /// <summary>
    /// Beskrivelse av skredet
    /// </summary>
    public string? Description {get;set;}

    /// <summary>
    /// Navn på stedet
    /// </summary>
    public string? Place {get;set;}

    /// <summary>
    /// Dato for når det skjedde
    /// </summary>
    public DateTime IncidentDate {get;set;}

    /// <summary>
    /// Beskrivelse av evt. skade 
    /// </summary>
    public string? DamageDescription {get;set;}


    /// <summary>
    /// Fra position for skredet
    /// </summary>
    public UtmPoint FromPosition {get;set;}

    /// <summary>
    /// Til position for skredet
    /// </summary>
    public UtmPoint ToPosition {get;set;}

    /// <summary>
    /// Bounding box for FromPosition and ToPosition, brukes for søk
    /// </summary>
    public BBox BoundingBox {get;set;}
    /// <summary>
    /// Opprettet dato
    /// </summary>
    public DateTime Created {get;set;}

    /// <summary>
    /// Oppdatert dato
    /// </summary>
    public DateTime Updated {get;set;}

    public List<string> ImageUris {get;set;}
    public IEnumerable<ClosedRoadDto> ClosedRoads {get;set;}

}