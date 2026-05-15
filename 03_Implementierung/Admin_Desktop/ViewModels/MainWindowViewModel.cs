using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared;

namespace Admin_Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [RelayCommand]
    private void ZeigeMitarbeiter() => AktiverTab = new MitarbeiterViewModel();

    [RelayCommand]
    private void ZeigeZeiten() => AktiverTab = new ZeitenViewModel();

    [RelayCommand]
    private void ZeigeDashboard() => AktiverTab = new DashboardViewModel();

    [RelayCommand]
    private void ZeigeEinstellungen() => AktiverTab = new EinstellungenViewModel();
    
    [ObservableProperty]
    private ObservableCollection<Mitarbeiter> _mitarbeiter = new();
    
    [ObservableProperty]
    private ViewModelBase _aktiverTab = new MitarbeiterViewModel();
    
    
    public MainWindowViewModel()
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
    
    
}
