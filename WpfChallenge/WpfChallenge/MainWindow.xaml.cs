using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfChallenge.Domain.Models;
using WpfChallenge.Domain.Services;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClienteServices _clienteService;


        public MainWindow(ClienteServices clienteServices)
        {
            _clienteService = clienteServices;
            InitializeComponent();
            PopularGrid();
        }

        private void btnSalvarClick(object sender, RoutedEventArgs e)
        {
            var cliente = new Cliente()
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Endereco = txtEndereco.Text,

            };
            var result = this._clienteService.Save(cliente);

            PopularGrid();
            MessageBox.Show(result.Message);

        }
        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag.ToString();

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja excluir o Cliente selecionado?", "Atenção", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var resultItem = _clienteService.Delete(Convert.ToInt32(id));
                if (resultItem.Success)
                {
                    PopularGrid();
                    MessageBox.Show("Cliente excluído com sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao excluir registro");
                }
            }

            PopularGrid();

        }

        private void btnEditarGrid_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag.ToString();
            var clienteDB = _clienteService.GetCliente(Convert.ToInt32(id));

            txtNome.Text = clienteDB.Nome;
            txtEmail.Text = clienteDB.Email;
            txtTelefone.Text = clienteDB.Telefone;
            txtEndereco.Text = clienteDB.Endereco;

            btnSalvar.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Visible;
        }
        private void btnEditarClick(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag.ToString();
            var cliente = new Cliente()
            {
                Id = Convert.ToInt32(id),
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Endereco = txtEndereco.Text,

            };
            var result = this._clienteService.Update(cliente);

            MessageBox.Show(result.Message);
            PopularGrid();

        }


        private void PopularGrid()
        {
            List<Cliente> listaTemporaria = new List<Cliente>();
            var cliente = new Cliente()
            {
                Nome = "Guilherme Dantas",
                Email = "guiiabdn@gmail.com",
                Telefone = "61982875484",
                Endereco = "SHTN Trecho 2, Bloco B2, Apt 1009"
            };


            //Foi criado uma listaTemporaria de Clientes apenas para visualização da Grid. 
            listaTemporaria.Add(cliente);

            // var itens = _clienteService.ListCliente();
            
            dataGrid.ItemsSource = listaTemporaria;
        }
    }
}

