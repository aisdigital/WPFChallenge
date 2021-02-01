using System;
using System.Collections.Generic;
using System.Data;
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
using WpfChallenge.Models;
using WpfChallenge.Repository;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IClienteRepository _clienteRepository;
        public MainWindow()
        {
            InitializeComponent();
            LimpaTexto();
            retornaTodosDados();

            Add.IsEnabled = false;
            Update.IsEnabled = false;
            Delete.IsEnabled = false;
        }

        public void Limpar()
        {
            txtIdentificador.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;

        }

        public void LimpaTexto()
        {
            Limpar();

            Add.IsEnabled = false;
            chkAdd.IsChecked = false;
            Update.IsEnabled = false;
            Delete.IsEnabled = false;
        }

        public void retornaTodosDados()
        {
            try
            {
                _clienteRepository = new ClienteRepository();
                dtGrid.DataContext = _clienteRepository.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void preencheGrid(int Id)
        {
            dtGrid.DataContext = retornaDadosPorId(Id);
        }

        public DataTable retornaDadosPorId(int Id)
        {
            try
            {
                _clienteRepository = new ClienteRepository();
                return _clienteRepository.Get(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void insereDados(Cliente cliente)
        {
            try
            {
                _clienteRepository = new ClienteRepository();
                dtGrid.DataContext = _clienteRepository.Post(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void alteraDados(Cliente cliente)
        {
            try
            {
                _clienteRepository = new ClienteRepository();
                dtGrid.DataContext = _clienteRepository.Put(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void deletaDados(int Id)
        {
            try
            {
                _clienteRepository = new ClienteRepository();
                if (_clienteRepository.Delete(Id))
                    retornaTodosDados();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Limpa_Campos_Click(object sender, RoutedEventArgs e)
        {
            LimpaTexto();
            retornaTodosDados();
        }

        private void btnPesquisaPorId_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdentificador.Text))
            {
                preencheGrid(Convert.ToInt32(txtIdentificador.Text));
                LimpaTexto();
                if (Add.IsEnabled) Add.IsEnabled = false;
                if (Update.IsEnabled) Update.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("É necessário preencher com o Identificador.", "Informação!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void chkAdd_Click(object sender, RoutedEventArgs e)
        {
            if (chkAdd.IsChecked == true)
            {
                Add.IsEnabled = true;
                txtIdentificador.IsEnabled = false;
                Limpar();
                Update.IsEnabled = false;
                Delete.IsEnabled = false;
            }
            else
            {
                Add.IsEnabled = false;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Name = txtName.Text;
            cliente.Email = txtEmail.Text;
            cliente.Phone = txtPhone.Text;
            cliente.Address = txtAddress.Text;

            insereDados(cliente);
            LimpaTexto();
            txtIdentificador.IsEnabled = false;
            chkAdd.IsChecked = false;
            chkAdd_Click(null, null);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtIdentificador.Text))
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(txtIdentificador.Text);
                cliente.Name = txtName.Text;
                cliente.Email = txtEmail.Text;
                cliente.Phone = txtPhone.Text;
                cliente.Address = txtAddress.Text;
                alteraDados(cliente);

                LimpaTexto();
            }
            else
            {
                MessageBox.Show("É necessário preencher com o Identificador.", "Informação!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdentificador.Text))
            {
                var cellInfo = dtGrid.SelectedCells[0];
                var content = cellInfo.Column.GetCellContent(cellInfo.Item);
                deletaDados(Convert.ToInt32(((System.Data.DataRowView)cellInfo.Item).Row.ItemArray[0]));
                retornaTodosDados();
                LimpaTexto();
            }
            else
            {
                MessageBox.Show("É necessário preencher com o Identificador.", "Informação!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cellInfo = dtGrid.SelectedCells[0];
                var content = cellInfo.Column.GetCellContent(cellInfo.Item);

                DataTable dt = retornaDadosPorId(Convert.ToInt32(((System.Data.DataRowView)cellInfo.Item).Row.ItemArray[0]));
                DataRow[] rows = dt.Select();
                txtIdentificador.Text = rows[0].ItemArray[0].ToString();
                txtName.Text = rows[0].ItemArray[1].ToString();
                txtEmail.Text = rows[0].ItemArray[2].ToString();
                txtPhone.Text = rows[0].ItemArray[3].ToString();
                txtAddress.Text = rows[0].ItemArray[4].ToString();

                txtIdentificador.IsEnabled = false;
                Update.IsEnabled = true;
                Delete.IsEnabled = true;
                chkAdd_Click(null, null);
            }
            catch (Exception ex)
            {
                if (((System.ArgumentOutOfRangeException)ex).Message
                    .Equals("Argumento especificado estava fora do intervalo de valores válidos.\r\nNome do parâmetro: index"))
                {
                    MessageBox.Show("Selecione um registro no Grid", "Informação!", MessageBoxButton.OK, MessageBoxImage.Information);
                };
            }
        }
    }
}
