namespace GrooveSharp.Xaml.ViewModels
{
    using System.Windows.Input;
    using Techdencias.Mvvm.Metro.Base;
    using Techdencias.Mvvm.Metro.Commands;

    public class SecondViewModel : ViewModelBase
    {
        private static int numberOfIstance = 0;
        private string title;

        public SecondViewModel()
        {
            numberOfIstance++;
        }

        public int NumberOfIstance
        {
            get { return numberOfIstance; }
        }
        
        public ICommand GoBackCommand
        {
            get { return new DelegateCommand<object>(_ => NavigationService.GoBack()); }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; OnPropertyChanged("Title"); EventAggregator.Notify(this.title); }
        }
    }
}