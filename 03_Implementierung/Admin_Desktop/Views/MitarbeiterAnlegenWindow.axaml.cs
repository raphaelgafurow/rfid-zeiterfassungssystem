using Avalonia.Controls;
using Admin_Desktop.ViewModels;
using Shared;

namespace Admin_Desktop.Views;

public partial class MitarbeiterAnlegenWindow : Window
{
    public MitarbeiterAnlegenViewModel ViewModel => (MitarbeiterAnlegenViewModel)DataContext!;
    public MitarbeiterAnlegenWindow(Mitarbeiter? mitarbeiter = null)
    {
        InitializeComponent();
        
        DataContext = new MitarbeiterAnlegenViewModel(mitarbeiter);
        
        AbbrechenButton.Click += (_, _) => Close();
        
        var vm = (MitarbeiterAnlegenViewModel)DataContext;
        vm.Gespeichert += Close;
    }
}