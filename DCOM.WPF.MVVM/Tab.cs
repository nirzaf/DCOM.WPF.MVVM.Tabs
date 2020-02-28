namespace DCOM.WPF.MVVM
{
    using System;
    using System.Windows.Input;

    public abstract class Tab : ITab
    {
        public Tab()
        {
            CloseCommand = new ActionCommand(p => CloseRequested?.Invoke(this, EventArgs.Empty));
        }
        public string Name { get; set; }
        public ICommand CloseCommand { get; }
        public event EventHandler CloseRequested;
    }
}