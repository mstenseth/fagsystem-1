using fagsystem_1.Domain.Managers;
using fagsystem_1.Dtos;
using fagsystem_1.Utils;
using Microsoft.AspNetCore.Mvc;

namespace fagsystem_1.Controllers;

[ApiController]
[Route("[controller]")]
public class NatureIncidentController : ControllerBase
{
    private readonly ILogger<NatureIncidentController> _logger;
    private readonly INatureIncidentManager _natureIncidentManager;

    public NatureIncidentController(ILogger<NatureIncidentController> logger, INatureIncidentManager natureIncidentManager)
    {
        _logger = logger;
        _natureIncidentManager = natureIncidentManager;
    }

    [HttpGet(Name = "GetAllNatureIncidents")]
    public async Task<IEnumerable<NatureIncidentDto>> GetAllNatureIncidents()
    {
        var res = await _natureIncidentManager.GetAllNatureIncidentsAsync();
        return res;
    }

    [HttpGet("search", Name = "SearchNatureIncidents")]
    public async Task<IEnumerable<NatureIncidentDto>> SearchNatureIncidents(DateTime? minDate,DateTime? maxDate,double? bottom,double? left, double? top, double? right)
    {
        var allItems = await _natureIncidentManager.GetAllNatureIncidentsAsync();
        var filtered = allItems.AsQueryable();

        if( minDate.HasValue)
        {
            filtered = filtered.Where( x => x.IncidentDate >= minDate);
        }
        if( maxDate.HasValue)
        {
            filtered = filtered.Where( x => x.IncidentDate < maxDate);
        }
        
        var tmpFilteredItems = filtered.ToList();
        var filteredItems = new List<NatureIncidentDto>();

        // Hvis bbox areal er innsendt, legg til kun items som intersects.
        if( left.HasValue && bottom.HasValue && right.HasValue && top.HasValue)
        {
            var bboxSearchArea = new BBox
            {
                Left = left.Value,
                Bottom = bottom.Value,
                Right = right.Value,
                Top = top.Value
            };

            foreach( var item in tmpFilteredItems)
            {
                if( GeoUtils.BBoxIntersects(item.BoundingBox,bboxSearchArea))
                {
                    filteredItems.Add(item);
                }

            }
        }else{
            filteredItems = tmpFilteredItems;
        }

        return filteredItems;
    }

}

