namespace fagsystem_1.Dtos;

public class ClosedRoadDto
{
    public ClosedRoadDto()
    {
        LineSegments = new List<UtmPoint>();
    }
    public int Id {get;set;}

    /// <summary>
    /// Line segments
    /// </summary>
    public ICollection<UtmPoint> LineSegments{ get;set;}
    
    /// <summary>
    /// Dato stengingen gjelder fra 
    /// </summary>
    public DateTime ClosedFrom {get;set;}

    /// Dato stengingen gjelder til
    public DateTime ClosedTo {get;set;}
}