using fagsystem_1.Dtos;
using fagsystem_1.Utils;

namespace fagsystem_1.Domain.Managers;

public interface INatureIncidentManager
{
    Task<IEnumerable<NatureIncidentDto>> GetAllNatureIncidentsAsync();
}

public class NatureIncidentManager : INatureIncidentManager
{
    public Task<IEnumerable<NatureIncidentDto>> GetAllNatureIncidentsAsync()
    {
        var res = new List<NatureIncidentDto>
        {
            CreateEV18Damage1(),
            CreateEV16Damage1()
        };

        return Task.FromResult(res.AsEnumerable());
    }

    private NatureIncidentDto CreateEV18Damage1()
    {
        var now = DateTime.UtcNow;
        var item = new NatureIncidentDto
        {
            Id = 1,
            Type = Constants.NatureIncidentType.Sorpeskred,
            Description = "En beskrivelse",
            Place = "E18 Sandvika",
            IncidentDate = new DateTime(2023,12,23,22,10,1),
            DamageDescription = "Ingen skade.",
            FromPosition = new UtmPoint{ X = 249628.696, Y = 6647419.859}, // https://vegkart.atlas.vegvesen.no/#kartlag:geodata/@250427,6647457,14/vegsystemreferanse:249628.696:6647419.859
            ToPosition = new UtmPoint{ X = 249674.11, Y = 6647463.375},   // https://vegkart.atlas.vegvesen.no/#kartlag:geodata/@250427,6647457,14/vegsystemreferanse:249674.11:6647463.375
            Created = now,
            Updated = now
            
        };
        var closedRoad = new ClosedRoadDto
        {
            Id = 1,
            
        };
        closedRoad.LineSegments.Add(new UtmPoint{X =249491.56,Y = 6647278.493});   // https://vegkart.atlas.vegvesen.no/#kartlag:geodata/@250427,6647457,14/vegsystemreferanse:249491.56:6647278.493
        closedRoad.LineSegments.Add(new UtmPoint{X = 250081.022, Y =6647715.5});   // https://vegkart.atlas.vegvesen.no/#kartlag:geodata/@250427,6647457,14/vegsystemreferanse:250081.022:6647715.5
        // Tatt fra vegbilder.atlas.vegvesen.no
        item.ImageUris.Add("https://s3vegbilder.atlas.vegvesen.no/vegfoto-prod-w-2023/Planar/EV00018/S52/D1_m207_KD2/F1_2023_06_16/EV00018_S52D1_m207_KD2_m00446_f1.jpg?st=2024-02-22T05:30:24Z&se=2024-02-22T15:30:24Z&sp=mr&sv=vf001&sig=AcaVLy7BIy7w86q3L5Az/oojsywxOzxeBIAqI1vAjX8=");
        item.BoundingBox = GeoUtils.CalcBbox([item.FromPosition,item.ToPosition]);

        return item;
    }

    private NatureIncidentDto CreateEV16Damage1()
    {
        var now = DateTime.UtcNow;
        var item = new NatureIncidentDto
        {
            Id = 1,
            Type = Constants.NatureIncidentType.Sorpeskred,
            Description = "En beskrivelse",
            Place = "Ett sted i bærum",
            IncidentDate = new DateTime(2024,1,2,22,10,1),
            DamageDescription = "Skadet skilt.",
            FromPosition = new UtmPoint{ X = 245045.534, Y = 6652985.591}, // https://vegkart.atlas.vegvesen.no/#kartlag:geodata/@252779,6648247,11/vegsystemreferanse:245045.534:6652985.591
            ToPosition = new UtmPoint{ X = 246092.756, Y = 6652000.863},   // https://vegkart.atlas.vegvesen.no/#kartlag:geodata/@252779,6648247,11/vegsystemreferanse:246092.756:6652000.863
            Created = now,
            Updated = now
            
        };
        // Tatt fra vegbilder.atlas.vegvesen.no
        item.ImageUris.Add("https://s3vegbilder.atlas.vegvesen.no/vegfoto-prod-w-2023/Planar/EV00016/S47/D70/F1_2023_07_31/EV00016_S47D70_m01653_f1.jpg?st=2024-02-22T05:45:37Z&se=2024-02-22T15:45:37Z&sp=mr&sv=vf001&sig=K+Q9fhJt64t3Zql04aHhFLk35qxhMN5MU0i/Tv8MaPI=");
        item.BoundingBox = GeoUtils.CalcBbox([item.FromPosition,item.ToPosition]);
        return item;
    }

}