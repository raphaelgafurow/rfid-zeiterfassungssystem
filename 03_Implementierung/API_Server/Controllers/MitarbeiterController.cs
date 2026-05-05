using Microsoft.AspNetCore.Mvc;
using API_Server.Data;
using Shared;

namespace API_Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MitarbeiterController : ControllerBase
{
    private readonly AppDbContext _db;

    public MitarbeiterController(AppDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public ActionResult<List<Mitarbeiter>> GetAlle()
    {
        return Ok(_db.Mitarbeiter.ToList());
    } 
    
    [HttpPost]
    public ActionResult<Mitarbeiter> Erstellen(Mitarbeiter mitarbeiter)
    {
        _db.Mitarbeiter.Add(mitarbeiter);
        _db.SaveChanges();
        return Ok(mitarbeiter);
    }
}

