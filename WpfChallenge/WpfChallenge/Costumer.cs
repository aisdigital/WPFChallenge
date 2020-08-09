using System;


namespace WpfChallenge
{
    class Costumer: BaseNotifyPropertyChanged, ICloneable
    {
        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetField(ref _Name, value);
        }

        private string _Email;
        public string Email
        {
            get => _Email;
            set => SetField(ref _Email, value);
        }

        private string _Phone;
        public string Phone
        {
            get => _Phone;
            set => SetField(ref _Phone, value);
        }

        private string _Address;
        public string Address
        {
            get => _Address;
            set => SetField(ref _Address, value);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
