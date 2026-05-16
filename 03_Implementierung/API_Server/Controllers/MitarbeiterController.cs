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
    
    [HttpPut("{id}")]
    public ActionResult<Mitarbeiter> Aktualisieren(int id, Mitarbeiter mitarbeiter)
    {
        var eintrag = _db.Mitarbeiter.Find(id);
        if (eintrag == null) return NotFound();
    
        eintrag.Vorname = mitarbeiter.Vorname;
        eintrag.Nachname = mitarbeiter.Nachname;
        eintrag.Personalnummer = mitarbeiter.Personalnummer;
        eintrag.Abteilung = mitarbeiter.Abteilung;
        eintrag.Rolle = mitarbeiter.Rolle;
    
        _db.SaveChanges();
        return Ok(eintrag);
    }
}

