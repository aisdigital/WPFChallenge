using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WpfChallenge.Domain.Interfaces.Test;

namespace WpfChallenge.Domain.Models
{
    public class MainWindowProvider : IMainWindowProvider
    {
        public Window GetMainWindow() => Application.Current.MainWindow;
    }
}
