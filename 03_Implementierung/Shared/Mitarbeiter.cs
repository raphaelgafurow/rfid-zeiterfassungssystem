namespace Shared;

public class Mitarbeiter
{
    public int MitarbeiterID { get; set; } 
    public string Vorname { get; set; } = string.Empty;
    public string Nachname { get; set; } = string.Empty;
    public string Personalnummer { get; set; } = string.Empty;
    public bool Aktiv { get; set; }
    public string Abteilung { get; set; } = string.Empty;
    public string Rolle { get; set; } = "Mitarbeiter";
    public int Urlaubstage { get; set; } = 30;
    public decimal Arbeitszeitkonto { get; set; } = 0;
}