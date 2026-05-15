using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Shared;

namespace Admin_Desktop.ViewModels;

public partial class MitarbeiterViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<Mitarbeiter> _mitarbeiter = new();
    
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
}