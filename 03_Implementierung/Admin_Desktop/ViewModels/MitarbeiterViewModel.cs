using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Shared;
using CommunityToolkit.Mvvm.Input;
using Admin_Desktop.Views;

namespace Admin_Desktop.ViewModels;

public partial class MitarbeiterViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _mitarbeiterSuche = string.Empty;
    
    [ObservableProperty]
    private ObservableCollection<Mitarbeiter> _mitarbeiter = new();
    
    [ObservableProperty]
    private Mitarbeiter? _ausgewählterMitarbeiter;
    
    
    public MitarbeiterViewModel()
    {
        if (!Design.IsDesignMode)
        {
            LadeMitarbeiter();
        }
    }

    private async void LadeMitarbeiter()
    {
        try
        {
            var client = new HttpClient();
            var liste = await client.GetFromJsonAsync<List<Mitarbeiter>>("http://localhost:5210/api/mitarbeiter");
            if (liste != null)
            {
                Mitarbeiter = new ObservableCollection<Mitarbeiter>(liste);
            }
        }
        catch
        {
            
        }
    }

    [RelayCommand]
    private void NeuerMitarbeiter()
    {
        var fenster = new MitarbeiterAnlegenWindow();
        fenster.ViewModel.Gespeichert += LadeMitarbeiter;
        fenster.Show();
    }
    
    
    [RelayCommand]
    private void MitarbeiterBearbeiten()
    {
        var fenster = new MitarbeiterAnlegenWindow(AusgewählterMitarbeiter);
        fenster.ViewModel.Gespeichert += LadeMitarbeiter;
        fenster.Show();
    }

    [RelayCommand]
    private async Task MitarbeiterDeaktivieren()
    {
        if (AusgewählterMitarbeiter == null)
        {
            return;
        }
        else
        {
            var client = new HttpClient();
            var mitarbeiter = AusgewählterMitarbeiter;
            mitarbeiter.Aktiv = false;
            await client.PutAsJsonAsync($"http://localhost:5210/api/mitarbeiter/{mitarbeiter.MitarbeiterID}", mitarbeiter);
            LadeMitarbeiter();
        }
    }
    
    public IEnumerable<Mitarbeiter> GefilterteMitarbeiter =>
        string.IsNullOrEmpty(MitarbeiterSuche)
            ? Mitarbeiter
            : Mitarbeiter.Where(m => 
                m.Vorname.Contains(MitarbeiterSuche, StringComparison.OrdinalIgnoreCase) ||
                m.Nachname.Contains(MitarbeiterSuche, StringComparison.OrdinalIgnoreCase));
    
    partial void OnMitarbeiterSucheChanged(string value)
    {
        OnPropertyChanged(nameof(GefilterteMitarbeiter));
    }
    
    partial void OnMitarbeiterChanged(ObservableCollection<Mitarbeiter> value)
    {
        OnPropertyChanged(nameof(GefilterteMitarbeiter));
    }
}