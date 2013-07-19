namespace GrooveSharp.Xaml
{
    using Techdencias.Mvvm.Metro.InversionOfControl;

    sealed partial class App 
    {
        public App() : base()
        {
            this.InitializeComponent();
        }

        protected override void SaveStateBeforeSuspend(IContainer container)
        {
        }

        protected override void LoadStateFromSuspended(IContainer container)
        {
        }
    }
}
