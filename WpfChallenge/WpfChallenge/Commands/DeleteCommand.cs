using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChallenge.Commands
{
    public class DeleteCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            var viewModel = parameter as CostumersViewModel;
            return viewModel != null && viewModel.CostumerSelected != null;
        }

        public override void Execute(object parameter)
        {
            var viewModel = (CostumersViewModel)parameter;
            viewModel.Costumers.Remove(viewModel.CostumerSelected);
            viewModel.CostumerSelected = viewModel.Costumers.FirstOrDefault();
        }
    }
}
