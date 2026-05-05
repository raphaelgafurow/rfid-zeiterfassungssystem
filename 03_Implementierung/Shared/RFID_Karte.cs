using System.ComponentModel.DataAnnotations;

namespace Shared;

public class RFID_Karte
{
    public string RFID_UID { get; set; } = string.Empty;
    [Key]
    public int KartenID  { get; set; }
    public int MitarbeiterID { get; set; }
}