namespace DCOM.WPF.MVVM
{
    using System;
    using System.Windows.Input;

    public interface ITab
    {
        string Name { get; set; }
        ICommand CloseCommand { get; }
        event EventHandler CloseRequested;
    }
}