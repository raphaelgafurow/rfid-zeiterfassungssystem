using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http;
using System.Net.Http.Json;
using Shared;
using System.Threading.Tasks;

namespace Admin_Desktop.ViewModels;

public partial class MitarbeiterAnlegenViewModel : ViewModelBase
{
    public event Action? Gespeichert;
    
    [ObservableProperty]
    private string _vorname = string.Empty;

    [ObservableProperty]
    private string _nachname = string.Empty;
    
    [ObservableProperty]
    private string _personalnummer = string.Empty;
    
    [ObservableProperty]
    private string _abteilung = string.Empty;
    
    [ObservableProperty]
    private string _rolle = string.Empty;

    [RelayCommand]
    private async Task Speichern()
    {
        var mitarbeiter = new Mitarbeiter()
        {
            Vorname = this.Vorname,
            Nachname = this.Nachname,
            Personalnummer = this.Personalnummer,
            Abteilung = this.Abteilung,
            Rolle = this.Rolle,
            Aktiv = true
        };
        
        var client = new HttpClient();
        await 
            client.PostAsJsonAsync("http://localhost:5210/api/mitarbeiter/", mitarbeiter);
        
        Gespeichert?.Invoke();
    }
    
    
}