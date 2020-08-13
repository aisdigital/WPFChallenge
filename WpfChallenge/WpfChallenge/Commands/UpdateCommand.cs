using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfChallenge.Models;
using WpfChallenge.ViewModel;

namespace WpfChallenge.Commands
{
    public class UpdateCommand : ICommand
    {
        #region ICommand Members  

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            CustomerViewModel viewModel = (CustomerViewModel)parameter;

            Customer customer = viewModel.selectedCustomer;

            // TODO Verify fields are empty
            if (customer.name == null && customer.phone == null && customer.address == null)
            {
                // Display Alert
                _ = MessageBox.Show("New Customer fFields are empty", "WPF Challenge",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                viewModel.selectedCustomer = new Customer();
            }
        }

        #endregion
    }
}
