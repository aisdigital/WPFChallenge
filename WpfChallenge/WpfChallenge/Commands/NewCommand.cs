using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfChallenge.Commands
{
    public class NewCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            return parameter is CostumersViewModel;
        }

        public override void Execute(object parameter)
        {
            var viewModel = (CostumersViewModel)parameter;
            var Costumer = new Costumer();

            var fw = new CostumerWindow();
            fw.DataContext = Costumer;
            fw.ShowDialog();

            if (fw.DialogResult.HasValue && fw.DialogResult.Value)
            {
                viewModel.Costumers.Add(Costumer);
                viewModel.CostumerSelected = Costumer;
            }
        }
    }
}
