using System.Windows;
using Domain.Handlers;
using Domain.Commands;
using Shared.Commands;
using System.Collections.Generic;
using WpfChallenge.ViewModels;
using System.ComponentModel.DataAnnotations;
using Shared.Notifications;
using Domain.Repositories;
using System.Data;
using System.Windows.Controls;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace WpfChallenge
{
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClienteHandler _handler;
        private readonly IClienteRepository _clienteRepository;

        public MainWindow(ClienteHandler handler,IClienteRepository clienteRepository)
        {            
            _handler = handler;
            _clienteRepository = clienteRepository;                       
            InitializeComponent();
            PopularEstados();
            PopularGrid();
        }
        
        #region Popular Listas
        private void PopularEstados()
        {
            lstUF.Items.Add("AC");
            lstUF.Items.Add("AL");
            lstUF.Items.Add("AP");
            lstUF.Items.Add("AM");
            lstUF.Items.Add("BA");
            lstUF.Items.Add("CE");
            lstUF.Items.Add("DF");
            lstUF.Items.Add("ES");
            lstUF.Items.Add("GO");
            lstUF.Items.Add("MA");
            lstUF.Items.Add("MT");
            lstUF.Items.Add("MS");
            lstUF.Items.Add("MG");
            lstUF.Items.Add("PA");
            lstUF.Items.Add("PB");
            lstUF.Items.Add("PR");
            lstUF.Items.Add("PE");
            lstUF.Items.Add("PI");
            lstUF.Items.Add("RJ");
            lstUF.Items.Add("RN");
            lstUF.Items.Add("RS");
            lstUF.Items.Add("RO");
            lstUF.Items.Add("RR");
            lstUF.Items.Add("SC");
            lstUF.Items.Add("SP");
            lstUF.Items.Add("SE");
            lstUF.Items.Add("TO");
        }

        private void PopularGrid()
        {
            var itens = _clienteRepository.Listar();
            dataGrid.ItemsSource = itens;
        }

        #endregion

        #region Actions Buttons

        private void btnCadastrarClick(object sender, RoutedEventArgs e)
        {
            var cliente = (ClienteViewModel)this.DataContext;
            
            if (cliente.IsValid())
            {               
                var command = new CadastrarClienteCommand()
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone,
                    CEP = cliente.CEP,
                    UF = cliente.UF,
                    Bairro = cliente.Bairro,
                    Cidade = cliente.Cidade,
                    Complemento = cliente.Complemento,
                    Logradouro = cliente.Logradouro,
                    Numero = cliente.Numero
                };
                var result = this._handler.Handle(command);

                if (result.Success)
                {
                    this.DataContext = new ClienteViewModel();
                    PopularGrid();
                    MessageBox.Show(result.Data.ToString(),"Atenção !");                    
                }
                else
                {
                    string mensagem = string.Empty;

                    foreach (var item in (IReadOnlyCollection<Notification>)result.Data)
                    {
                        mensagem += item.Message;
                    }
                    MessageBox.Show(mensagem);
                }
            } 
           
        }     

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag.ToString();

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Você deseja excluir o registro selecionado?", "Atenção", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var excluido = _clienteRepository.Excluir(Guid.Parse(id));
                if (excluido)
                {
                    PopularGrid();
                    MessageBox.Show("Registro excluído com sucesso","Atenção!");
                }
                else
                {
                    MessageBox.Show("Erro ao excluir registro", "Atenção!");
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag.ToString();
            var cliente = _clienteRepository.Get(Guid.Parse(id));
            var viewModel = new ClienteViewModel()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                CEP = cliente.CEP,
                UF = cliente.UF,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,
                Complemento = cliente.Complemento,
                Logradouro = cliente.Logradouro,
                Numero = cliente.Numero
            };
            this.DataContext = viewModel;
            btnCadastrar.Visibility = Visibility.Hidden;
            btnSalvar.Visibility = Visibility.Visible;
        }

        private void btnSalvarClick(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag.ToString();

            var cliente = (ClienteViewModel)this.DataContext;

            if (cliente.IsValid())
            {
                var command = new EditarClienteCommand()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone,
                    CEP = cliente.CEP,
                    UF = cliente.UF,
                    Bairro = cliente.Bairro,
                    Cidade = cliente.Cidade,
                    Complemento = cliente.Complemento,
                    Logradouro = cliente.Logradouro,
                    Numero = cliente.Numero
                };
                var result = this._handler.Handle(command);

                if (result.Success)
                {
                    this.DataContext = new ClienteViewModel();
                    PopularGrid();
                    MessageBox.Show(result.Data.ToString(),"Atenção !");
                    btnCadastrar.Visibility = Visibility.Visible;
                    btnSalvar.Visibility = Visibility.Hidden;
                }
                else
                {
                    string mensagem = string.Empty;

                    foreach (var item in (IReadOnlyCollection<Notification>)result.Data)
                    {
                        mensagem += item.Message;
                    }
                    MessageBox.Show(mensagem);
                }
            }
        }
        #endregion           

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
