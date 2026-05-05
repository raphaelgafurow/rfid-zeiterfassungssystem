namespace Shared;

public class Zeitbuchung
{
    public int BuchungsID { get; set; }
    public DateTime Zeitstempel { get; set; }
    public string Buchungstyp { get; set; } = string.Empty;
    public int MitarbeiterID { get; set; }
}