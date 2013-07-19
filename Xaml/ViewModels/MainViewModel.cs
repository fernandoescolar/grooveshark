namespace GrooveSharp.Xaml.ViewModels
{
    using System.Windows.Input;
    using Techdencias.Mvvm.Metro.Base;
    using Techdencias.Mvvm.Metro.Commands;

    public class MainViewModel : ViewModelBase
    {
        private static int numberOfIstance = 0;

        public MainViewModel()
        {
            numberOfIstance++;
        }

        public override void LoadParameter(object parameter)
        {
            EventAggregator.Subscribe<string>(OnTitleChange);
            base.LoadParameter(parameter);
        }

        private void OnTitleChange(string obj)
        {
            
        }

        public int NumberOfIstance
        {
            get { return numberOfIstance; }
        }

        public ICommand GoToSecondCommand
        {
            get { return new DelegateCommand<object>(_ => NavigationService.Navigate<SecondViewModel>()); }
        }
    }
}