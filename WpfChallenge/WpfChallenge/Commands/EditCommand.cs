using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChallenge.Commands
{
    class EditCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as CostumersViewModel;
            return viewModel != null && viewModel.CostumerSelected != null;
        }

        public override void Execute(object parameter)
        {
            var viewModel = (CostumersViewModel)parameter;
            var cloneCostumer = (Costumer)viewModel.CostumerSelected.Clone();
            var fw = new CostumerWindow();
            fw.DataContext = cloneCostumer;
            fw.ShowDialog();

            if (fw.DialogResult.HasValue && fw.DialogResult.Value)
            {
                viewModel.CostumerSelected.Name = cloneCostumer.Name;
                viewModel.CostumerSelected.Email = cloneCostumer.Email;
                viewModel.CostumerSelected.Phone = cloneCostumer.Phone;
                viewModel.CostumerSelected.Address = cloneCostumer.Address;
            }
        }
    }
}
