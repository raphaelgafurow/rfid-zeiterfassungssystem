using System.Collections.Generic;
using System.Collections.ObjectModel;
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

}