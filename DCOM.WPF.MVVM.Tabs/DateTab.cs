namespace DCOM.WPF.MVVM.Tabs
{
    using System;

    public class DateTab : Tab
    {
        public DateTab()
        {
            Name = DateTime.Now.ToString();
        }
    }
}