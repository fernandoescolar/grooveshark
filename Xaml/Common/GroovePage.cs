namespace GrooveSharp.Xaml.Common
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    public class GroovePage : Page
    {
        public MediaElement MediaPlayer { get; private set; }

        public GroovePage() : base()
        {
            var rootGrid = VisualTreeHelper.GetChild(Window.Current.Content, 0);
            this.MediaPlayer = (MediaElement)VisualTreeHelper.GetChild(rootGrid, 0);
        }
    }
}
