using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfChallenge.Models;

namespace WpfChallenge.ViewModel
{
    class CustomerViewModel :INotifyPropertyChanged
    {
        public Customer selectedCustomer { get; set; }
        public ObservableCollection<Customer> customers { get; set; }
        public CommandBinding NewCommand;

        public CustomerViewModel()
        {
            selectedCustomer = new Customer();
            customers = new ObservableCollection<Customer>
            {
                new Customer{name="John Due",phone="",address=""}
            };

        }


        private ICommand UpdateCommander;


        public ICommand UpdateCommand
        {
            get
            {
                if (UpdateCommander == null)
                    UpdateCommander = new Updater();
                return UpdateCommander;
            }
            set
            {
                UpdateCommander = value;
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
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
