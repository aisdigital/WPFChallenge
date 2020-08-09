using System.Windows;


namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for CostumerWindows.xaml
    /// </summary>
    public partial class CostumerWindow : Window
    {
        public CostumerWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
