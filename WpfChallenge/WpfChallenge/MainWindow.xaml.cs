using MyStockSys.Domain.Handlers;
using System;
using System.Windows;
using WpfChallenge.Data.Infra.Repositories.Transactions;
using WpfChallenge.Domain.Commands;
using WpfChallenge.Domain.Commands.Customer;
using WpfChallenge.Domain.Queries;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CustomerHandler _handler;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomerQueries _customerQueries;
        string strConexao = "";

        public MainWindow(CustomerHandler handler, IUnitOfWork unitOfWork, CustomerQueries customerQueries)
        {
            _handler = handler;
            _unitOfWork = unitOfWork;
            _customerQueries = customerQueries;
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadDataBase();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void LoadDataBase()
        {

        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            var command = new CreateCustomerCommand();
            command.Name = txtCustomerNome.Text;
            command.Email = txtCustomerEmail.Text;
            command.Phone = txtCustomerPhone.Text;
            command.Street = txtCustomerStreet.Text;
            command.Number = txtCustomerNumber.Text;
            command.Neighborhood = txtCustomerNeighborhood.Text;
            command.City = txtCustomerCity.Text;
            command.State = txtCustomerStreet.Text;

            var result = _handler.Handle(command).Result as CommandResult;

            if (result.Success)
            {
                _unitOfWork.SaveChanges();
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            var command = new DeleteCustomerCommand();

            command.Id = Guid.Parse(txtCustomerNome.Text);

            var result = _handler.Handle(command).Result as CommandResult;

            if (result.Success)
            {
                _unitOfWork.SaveChanges();

                // retorna a mensagem de sucesso com o objeto salvo

                //return result.Data;
            }
            else
            {
                //
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            var command = new UpdateCustomerCommand();

            command.Name = txtCustomerNome.Text;
            command.Email = txtCustomerEmail.Text;
            command.Phone = txtCustomerPhone.Text;
            command.Street = txtCustomerStreet.Text;
            command.Number = txtCustomerNumber.Text;
            command.Neighborhood = txtCustomerNeighborhood.Text;
            command.City = txtCustomerCity.Text;
            command.State = txtCustomerStreet.Text;

            var result = _handler.Handle(command).Result as CommandResult;

            if (result.Success)
            {
                _unitOfWork.SaveChanges();
                // retorna a mensagem de sucesso com o objeto salvo

                //return result.Data;
            }
        }

        private void grid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
