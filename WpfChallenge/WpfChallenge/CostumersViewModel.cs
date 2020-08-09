using System.Linq;

namespace WpfChallenge
{
    class CostumersViewModel : BaseNotifyPropertyChanged
    {
        public System.Collections.ObjectModel.ObservableCollection<Costumer> Costumers { get; private set; }


        public Commands.DeleteCommand Delete { get; private set; } = new Commands.DeleteCommand();
        public Commands.NewCommand New { get; private set; } = new Commands.NewCommand();
        public Commands.EditCommand Edit { get; private set; } = new Commands.EditCommand();

        private Costumer _CostumerSelected;
        public Costumer CostumerSelected
        {
            get => _CostumerSelected;
            set
            {
                SetField(ref _CostumerSelected, value);
                Delete.RaiseCanExecuteChanged();
                Edit.RaiseCanExecuteChanged();
            }
        }

        public CostumersViewModel()
        {
            Costumers = new System.Collections.ObjectModel.ObservableCollection<Costumer>();
            CostumerSelected = Costumers.FirstOrDefault();
        }
    }
}
