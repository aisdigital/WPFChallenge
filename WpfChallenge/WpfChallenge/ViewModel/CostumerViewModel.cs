using System.Collections.ObjectModel;
using WpfChallenge.Model;
using WpfChallenge.Controller;

namespace WpfChallenge.ViewModel
{
    public class CostumerViewModel : ObservableCollection<Costumer>
    {
        CostumerController costumer = new CostumerController();
        public CostumerViewModel()
        {
            readyCostumerCollection();
        }

        private void readyCostumerCollection()
        {
            foreach (var item in costumer.getAllCostumer())
            {
                Add(item);
            }                       
        }
    }
}
