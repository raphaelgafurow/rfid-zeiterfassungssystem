using Microsoft.AspNetCore.Mvc;
using API_Server.Data;
using Shared;
namespace API_Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ZeitbuchungController : ControllerBase
{
    private readonly AppDbContext _db;

    public ZeitbuchungController(AppDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public ActionResult<List<Zeitbuchung>> GetAlle()
    {
        return Ok(_db.Zeitbuchung.ToList());
    } 
    
    [HttpPost]
    public ActionResult<Zeitbuchung> Hinzufügen(Zeitbuchung zeitbuchung)
    {
        _db.Zeitbuchung.Add(zeitbuchung);
        _db.SaveChanges();
        return Ok(zeitbuchung);
    }
}