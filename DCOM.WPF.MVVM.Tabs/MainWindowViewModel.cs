namespace DCOM.WPF.MVVM.Tabs
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows.Input;
    
    public class MainWindowViewModel
    {
        private readonly ObservableCollection<ITab> tabs;
        public MainWindowViewModel()
        {
            NewTabCommand =  new ActionCommand(p => NewTab());

            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;

            Tabs = tabs;
        }

        public ICommand NewTabCommand { get; }
        public ICollection<ITab> Tabs { get; }

        private void NewTab()
        {
            Tabs.Add(new DateTab());
        }

        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ITab tab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (ITab) e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (ITab) e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }

        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            Tabs.Remove((ITab) sender);
        }
    }
}