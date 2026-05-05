namespace Shared;

public class Urlaub
{
    public DateOnly Enddatum { get; set; }
    public DateOnly Startdatum { get; set; }
    public bool Genehmigt { get; set; }
    public int UrlaubsID  { get; set; }
    public int MitarbeiterID{ get; set; }
}