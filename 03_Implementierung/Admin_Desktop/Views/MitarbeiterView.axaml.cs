using Avalonia.Controls;
using Admin_Desktop.ViewModels;
using Shared;

namespace Admin_Desktop.Views;

public partial class MitarbeiterView : UserControl
{
    public MitarbeiterView()
    {
        InitializeComponent();
        MitarbeiterGrid.SelectionChanged += (_, _) =>
        {
            if (DataContext is MitarbeiterViewModel vm)
                vm.AusgewählterMitarbeiter = MitarbeiterGrid.SelectedItem as Mitarbeiter;
        };
        
    }
    
    
}