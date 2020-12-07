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
using WpfChallenge.Models;
using WpfChallenge.Services;
using WpfChallenge.Utils;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string _newText = "* NEW *";
        private readonly CustomersService _customerService;

        private List<Customer> _customersList;

        public List<Customer> CustomersList {
            get {
                if (_customersList == null)
                {
                    _customersList = GetCustomersDataSource();
                }

                return _customersList;
            }

            set => _customersList = value;
        }

        private List<Customer> GetCustomersDataSource()
        {
            try
            {
                var customers = _customerService.GetAll();

                return customers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void LoadGrid(bool? refreshData = false)
        {
            if (refreshData.GetValueOrDefault(false))
            {
                CustomersList = GetCustomersDataSource();
            }

            CustomersGrid.ItemsSource = CustomersList;
        }

        public MainWindow()
        {
            InitializeComponent();

            _customerService = new CustomersService();

            LoadGrid();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
            CustomerIDField.Text = _newText;
            FormPanel.IsEnabled = true;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var criteria = SearchCriteria.Text.Trim();

            CustomersList = _customerService.Search(
                x => x.Name.Contains(criteria) ||
                x.Email.Contains(criteria) ||
                x.Phone.Contains(criteria) ||
                x.Address.Contains(criteria)
            );

            LoadGrid();
        }

        private void ClearForm()
        {
            CustomerIDField.Text = "";
            NameField.Text = "";
            EmailField.Text = "";
            PhoneField.Text = "";
            AddressField.Text = "";

            SearchCriteria.Text = "";

            FormPanel.IsEnabled = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var isNew = CustomerIDField.Text == _newText;
            Customer customer = null;

            if (isNew)
            {
                customer = new Customer();
            }
            else
            {
                var id = CustomerIDField.Text.Replace("ID: ", "").ToInt();
                customer = _customerService.FindById(id);
            }

            customer.Name = NameField.Text.Trim();
            customer.Email = EmailField.Text.Trim();
            customer.Phone = PhoneField.Text.Trim();
            customer.Address = AddressField.Text.Trim();

            if (isNew)
            {
                _customerService.Create(customer);
            }
            else
            {
                _customerService.Update(customer);
            }

            ClearForm();

            LoadGrid(true);
        }

        private void EditCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var customerID = ((Button)sender).CommandParameter.ToInt();

            LoadCustomerData(customerID);
            FormPanel.IsEnabled = true;
        }

        private void LoadCustomerData(int customerID)
        {
            var customer = CustomersList
                .SingleOrDefault(x => x.CustomerID == customerID);

            CustomerIDField.Text = $"ID: {customerID}";

            NameField.Text = customer.Name;
            EmailField.Text = customer.Email;
            PhoneField.Text = customer.Phone;
            AddressField.Text = customer.Address;
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var customerID = ((Button)sender).CommandParameter.ToInt();

            var confirmation = MessageBox.Show($"Are you sure to delete ID: {customerID}", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmation == MessageBoxResult.Yes)
            {
                try
                {
                    _customerService.Delete(customerID);

                    MessageBox.Show("Deleted", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                    LoadGrid(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
