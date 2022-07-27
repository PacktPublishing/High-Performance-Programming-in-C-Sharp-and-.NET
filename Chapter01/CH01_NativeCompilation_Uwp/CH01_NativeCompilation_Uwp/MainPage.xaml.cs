using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CH01_NativeCompilation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
 //       private PageResizer _pageResizer;

        public MainPage()
        {
            this.InitializeComponent();
            //this.Loaded += MainPage_Loaded;
        }

        //private void MainPage_Loaded(object sender, RoutedEventArgs e)
        //{
        //    _pageResizer = new PageResizer(this);
        //}

        private void GreetingButton_Click(object sender, RoutedEventArgs e)
        {
            GreetingTextBlock.Text = GreetingTextBox.Text;
        }
    }
}
