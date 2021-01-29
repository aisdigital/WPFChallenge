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
using WPFChallenge.Aplicacao.GestaoDeClientes;
using WPFChallenge.Aplicacao.GestaoDeClientes.Modelos;

namespace WpfChallenge
{
    public partial class MainWindow : Window
    {
        private readonly IServicoDeGestaoDeClientes _servicoDeGestaoDeClientes;
        public MainWindow(IServicoDeGestaoDeClientes servicoDeGestaoDeClientes)
        {
            InitializeComponent();

            this._servicoDeGestaoDeClientes = servicoDeGestaoDeClientes;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ListarClientes();
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos())
                return;

            var cliente = new ModeloDeCadastroDeCliente(txtNome.Text, txtEmail.Text, txtTelefone.Text, txtEndereco.Text);

            this._servicoDeGestaoDeClientes.Cadastrar(cliente);

            this.ListarClientes();

            this.LimparCampos();

            MessageBox.Show("Cadastro realizado com sucesso");
        }


        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            bool codigoPreenchido = !string.IsNullOrEmpty(this.txtCodigo.Text);

            if (!codigoPreenchido)
            {
                MessageBox.Show("Código vazio");
                return;
            }

            this._servicoDeGestaoDeClientes.Excluir(int.Parse(txtCodigo.Text));

            this.ListarClientes();
            
            LimparCampos();

            MessageBox.Show("Cadastro realizado com sucesso");

        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarCampos())
                return;

            var cliente = new ModeloDeEdicaoDeCliente(int.Parse(txtCodigo.Text), txtNome.Text, txtTelefone.Text, txtEndereco.Text);

            this._servicoDeGestaoDeClientes.Editar(cliente);
            this.ListarClientes();
            this.LimparCampos();

            MessageBox.Show("Atualizado com sucesso");

        }

        private void ClientesDG_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.ClientesDG.SelectedCells.Count > 0)
            {
                var cliente = ((ModeloDeClienteDaLista)ClientesDG.SelectedItem);

                if (cliente != null)
                {
                    this.txtCodigo.Text = cliente.Id.ToString();
                    this.txtNome.Text = cliente.Nome;
                    this.txtEmail.Text = cliente.Email;
                    this.txtTelefone.Text = cliente.Telefone;
                    this.txtEndereco.Text = cliente.Endereco;
                }
            }
        }

        private void LimparCampos()
        {
            txtCodigo.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtTelefone.Text = String.Empty;
            txtEndereco.Text = String.Empty;
        }



        private bool ValidarCampos()
        {
            bool nomePreenchido = !string.IsNullOrEmpty(this.txtNome.Text);
            bool emailPreenchido = !string.IsNullOrEmpty(this.txtEmail.Text);
            bool telefonePreenchido = !string.IsNullOrEmpty(this.txtTelefone.Text);
            bool enderecoPreenchido = !string.IsNullOrEmpty(this.txtEndereco.Text);

            if (!nomePreenchido)
            {
                MessageBox.Show("Nome vazio");
                return false;
            }

            if (!emailPreenchido)
            {
                MessageBox.Show("Email vazio");
                return false;
            }

            if (!telefonePreenchido)
            {
                MessageBox.Show("Telefone vazio");
                return false;
            }

            if (!enderecoPreenchido)
            {
                MessageBox.Show("Endereço vazio");
                return false;
            }

            return true;
        }

        private void ListarClientes()
        {
            var clientes = this._servicoDeGestaoDeClientes.Listar();
            ClientesDG.ItemsSource = clientes.Lista;
        }


    }
}
