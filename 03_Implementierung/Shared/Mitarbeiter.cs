namespace Shared;

public class Mitarbeiter
{
    public int MitarbeiterID { get; set; } 
    public string Vorname { get; set; } = string.Empty;
    public string Nachname { get; set; } = string.Empty;
    public string Personalnummer { get; set; } = string.Empty;
    public bool Aktiv { get; set; }
}