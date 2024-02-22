using fagsystem_1.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace fagsystem_1.Controllers;

[ApiController]
[Route("[controller]")]
public class NatureIncidentController : ControllerBase
{
    private readonly ILogger<NatureIncidentController> _logger;

    public NatureIncidentController(ILogger<NatureIncidentController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllNatureIncidents")]
    public IEnumerable<NatureIncidentDto> GetAllNatureIncidents()
    {
        var res = new List<NatureIncidentDto>();

        return res;

    }

}

