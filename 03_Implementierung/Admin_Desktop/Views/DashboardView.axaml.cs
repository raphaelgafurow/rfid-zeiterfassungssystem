using Admin_Desktop.ViewModels;
using Avalonia.Controls;

namespace Admin_Desktop.Views;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
        DataContext = new DashboardViewModel();
    }
}