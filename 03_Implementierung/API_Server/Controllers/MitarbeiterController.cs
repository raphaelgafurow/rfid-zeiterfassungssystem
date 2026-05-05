using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API_Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MitarbeiterController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Mitarbeiter>> GetAlle()
    {
        return Ok(new List<Mitarbeiter>());
    } 
}

