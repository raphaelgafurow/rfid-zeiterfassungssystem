using Avalonia.Controls;
using Admin_Desktop.ViewModels;

namespace Admin_Desktop.Views;

public partial class MitarbeiterAnlegenWindow : Window
{
    public MitarbeiterAnlegenViewModel ViewModel => (MitarbeiterAnlegenViewModel)DataContext!;
    public MitarbeiterAnlegenWindow()
    {
        InitializeComponent();
        
        DataContext = new MitarbeiterAnlegenViewModel();
        
        AbbrechenButton.Click += (_, _) => Close();
        
        var vm = (MitarbeiterAnlegenViewModel)DataContext;
        vm.Gespeichert += Close;
    }
}