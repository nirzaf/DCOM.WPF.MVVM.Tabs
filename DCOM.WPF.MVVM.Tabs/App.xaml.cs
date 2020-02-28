namespace DCOM.WPF.MVVM.Tabs
{
    using System.Windows;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var viewModel = new MainWindowViewModel();
            var view = new MainWindow() { DataContext = viewModel};

            view.ShowDialog();
        }
    }
}