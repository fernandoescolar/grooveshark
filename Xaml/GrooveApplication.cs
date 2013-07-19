namespace GrooveSharp.Xaml
{
    using Techdencias.Mvvm.Metro;
    using Techdencias.Mvvm.Metro.InversionOfControl;
    using ViewModels;
    using Views;
    using Windows.UI.Xaml.Controls;

    public abstract class GrooveApplication : MvvmApplication<MainViewModel>
    {
        protected override void SetUp(Frame rootFrame)
        {
            this.RegisterView<MainView>();
            this.RegisterView<SecondView>();

            this.RegisterViewModel<MainViewModel>(true);
            this.RegisterViewModel<SecondViewModel>(false);
        }

        protected override void SaveStateBeforeSuspend(IContainer container)
        {
        }

        protected override void LoadStateFromSuspended(IContainer container)
        {
        }
    }
}
