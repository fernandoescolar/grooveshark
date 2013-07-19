namespace GrooveSharp.Xaml.Views
{
    using System;
    using System.Collections.Generic;
    using ViewDefinitions;

    public sealed partial class SecondView : SecondViewBase
    {
        public SecondView()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
    }
}
