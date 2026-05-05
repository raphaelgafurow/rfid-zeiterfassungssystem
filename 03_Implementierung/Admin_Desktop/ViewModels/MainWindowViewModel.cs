using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using Shared;
namespace Admin_Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<Mitarbeiter> _mitarbeiter = new();
    
    public MainWindowViewModel()
    {
        LadeMitarbeiter();
    }

    private async void LadeMitarbeiter()
    {
        var client = new HttpClient();
        
        var liste = await client.GetFromJsonAsync<List<Mitarbeiter>>("http://localhost:5210/api/mitarbeiter");
        
        if (liste != null)
        {
            Mitarbeiter = new ObservableCollection<Mitarbeiter>(liste);
        }
    }
    
    
}
