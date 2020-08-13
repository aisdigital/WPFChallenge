using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Input;
using WpfChallenge.Models;
using WpfChallenge.Commands;

namespace WpfChallenge.ViewModel
{
    class CustomerViewModel :INotifyPropertyChanged
    {
        public Customer selectedCustomer { get; set; }
        public ObservableCollection<Customer> customers { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CreateCommand { get; set; }

        public CustomerViewModel()
        {
            selectedCustomer = new Customer();
            
            // TODO Add Persistence
            // Gerate Mockup Data
            customers = new ObservableCollection<Customer>
            {
                new Customer{name="John Due",phone="",address=""}
            };

            // Set Commands
            UpdateCommand = new Commands.UpdateCommand();
            DeleteCommand = new Commands.DeleteCommand();
            CreateCommand = new Commands.CreateCommand();
        }


        private void DeleteCustomer(Customer customer)
        {
            customers.Remove(customer);
        }

        private void NewCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


}
