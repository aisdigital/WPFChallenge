using System.ComponentModel;

namespace WpfChallenge.Model
{
    public class Costumer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
        }

        private string _id;
        private string _name;
        private string _email;
        private string _phone;
        private string _adress;

        public string id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Address
        {
            get { return _adress; }
            set
            {
                _adress = value;
                OnPropertyChanged("Address");
            }
        }

        public string getId()
        {
            return _id;
        }
    }
}
