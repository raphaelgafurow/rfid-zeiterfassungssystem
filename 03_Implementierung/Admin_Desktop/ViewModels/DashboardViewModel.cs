using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Shared;
using System.Linq;

namespace Admin_Desktop.ViewModels;

public partial class DashboardViewModel : ViewModelBase
{
    [ObservableProperty]
    private int _aktiveMitarbeiter;
    
    [ObservableProperty]
    private int _inaktiveMitarbeiter;
    
    public DashboardViewModel()
    {
        if (!Design.IsDesignMode)
        {
            LadeDaten();
        }
    }

    private async void LadeDaten()
    {
        try
        {
            var client = new HttpClient();
            var liste = await client.GetFromJsonAsync<List<Mitarbeiter>>("http://localhost:5210/api/mitarbeiter");
            if (liste != null)
            {
                AktiveMitarbeiter = liste.Count(m => m.Aktiv);

                InaktiveMitarbeiter = liste.Count(m => !m.Aktiv);
            }
        }
        catch
        {
            
        }
    }
}