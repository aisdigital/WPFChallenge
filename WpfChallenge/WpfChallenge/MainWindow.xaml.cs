using System.Windows;
using Domain.Handlers;
using Domain.Commands;
using Shared.Commands;
//using Unity;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClienteHandler _handler;
     
        public MainWindow(ClienteHandler handler)
        {

            _handler = handler;
            InitializeComponent();
        }   

        private void btnSalvarClick(object sender, RoutedEventArgs e)
        {
            string teste = this.txtBairro.Text.ToString();
            var command = new CadastrarClienteCommand();
            var result = this._handler.Handle(command);
        }
    }
}
