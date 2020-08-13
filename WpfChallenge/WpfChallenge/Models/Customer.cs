using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace WpfChallenge.Models
{
    class Customer : INotifyPropertyChanged
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private string _phone { get; set; }
        private string _address { get; set; }


        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
        }

        public string name
        {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        public string phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("phone");
            }
        }
        public string address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("address");
            }
        }

        public Customer()
        {
        }

        public Customer(Customer other)
        {
            id = other.id;
            name = other.name;
            phone = other.phone;
            address = other.address;
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
