using Microsoft.AspNetCore.Mvc;
using API_Server.Data;
using Shared;
namespace API_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RfidKarteController : ControllerBase
{
    private readonly AppDbContext _db;

    public RfidKarteController(AppDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public ActionResult<List<RFID_Karte>> GetAlle()
    {
        return Ok(_db.RFID_Karte.ToList());
    } 
    
    [HttpPost]
    public ActionResult<RFID_Karte> Hinzufügen(RFID_Karte rfidKarte)
    {
        _db.RFID_Karte.Add(rfidKarte);
        _db.SaveChanges();
        return Ok(rfidKarte);
    }
}