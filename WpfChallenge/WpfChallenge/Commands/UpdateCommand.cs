using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfChallenge.Models;
using WpfChallenge.ViewModel;

namespace WpfChallenge.Commands
{
    public class UpdateCommand : ICommand
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
}
