using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfChallenge.Classes;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Costumer mCostumer;
        bool mIsEditing;
        public MainWindow()
        {
            InitializeComponent();
            mIsEditing = false;
            PopUp.Visibility = Visibility.Hidden;
            UpdateBinding();
        }
       
        //Displayers
        private void UpdateBinding()
        {
            DisplayArea.ItemsSource = CostumerController.GetInstance().GetAllCostumers();
        }
        private void AutoFill(Costumer costumer)
        {
            NameInput.Text = costumer.GetName();
            EmailInput.Text = costumer.GetEmail();
            PhoneInput.Text = costumer.GetPhone();
            AddressInput.Text = costumer.GetAddess();
        }
        private void AutoClear()
        {
            NameInput.Text = "";
            EmailInput.Text = "";
            PhoneInput.Text = "";
            AddressInput.Text = "";
        }

        //Buttons
        private void NewCostumer(object sender, RoutedEventArgs e)
        {
            mCostumer = new Costumer();
            PopUp.Visibility = Visibility.Visible;
        }
        private void EditCostumer(object sender, RoutedEventArgs e)
        {
            mCostumer = new Costumer(CostumerController.GetInstance().GetCurrentCostumer());
            PopUp.Visibility = Visibility.Visible;
            mIsEditing = true;
            AutoFill(mCostumer);
        }
        private void DeleteCostumer(object sender, RoutedEventArgs e)
        {
            CostumerController.GetInstance().RemoveCostumer(DisplayArea.SelectedItem as Costumer);
            UpdateBinding();
        }


        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            if (mCostumer.ValidName() && mCostumer.ValidEmail() && mCostumer.ValidPhone() && mCostumer.ValidAddress())
            {
                if (mIsEditing)
                {
                    CostumerController.GetInstance().GetCurrentCostumer().CopyData(mCostumer);
                }
                else
                {
                    CostumerController.GetInstance().AddCostumer(mCostumer);
                }
                mIsEditing = false;
                PopUp.Visibility = Visibility.Hidden;
                AutoClear();
                UpdateBinding();
            }
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            PopUp.Visibility = Visibility.Hidden;
            AutoClear();
        }


        //InputReader
        private void NameInputValue(object sender, TextChangedEventArgs e)
        {
            mCostumer.SetName(NameInput.Text);
            if (mCostumer.GetName().Length == 0)
            {
                NameInput.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (mCostumer.ValidName())
            {
                NameInput.Background = new SolidColorBrush(Color.FromRgb(197, 247, 162));
            }
            else
            {
                NameInput.Background = new SolidColorBrush(Color.FromRgb(251, 137, 137));
            }
        }
        private void EmailInputValue(object sender, TextChangedEventArgs e)
        {
            mCostumer.SetEmail(EmailInput.Text);
            if (mCostumer.GetEmail().Length == 0)
            {
                EmailInput.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (mCostumer.ValidEmail())
            {
                EmailInput.Background = new SolidColorBrush(Color.FromRgb(197, 247, 162));
            }
            else
            {
                EmailInput.Background = new SolidColorBrush(Color.FromRgb(251, 137, 137));
            }
        }
        private void PhoneInputValue(object sender, TextChangedEventArgs e)
        {
            mCostumer.SetPhone(PhoneInput.Text);
            if (mCostumer.GetPhone().Length == 0)
            {
                PhoneInput.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (mCostumer.ValidPhone())
            {
                PhoneInput.Background = new SolidColorBrush(Color.FromRgb(197, 247, 162));
            }
            else
            {
                PhoneInput.Background = new SolidColorBrush(Color.FromRgb(251, 137, 137));
            }
        }
        private void AddressInputValue(object sender, TextChangedEventArgs e)
        {
            mCostumer.SetAddress(AddressInput.Text);
            if (mCostumer.GetAddess().Length == 0)
            {
                AddressInput.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else if (mCostumer.ValidAddress())
            {
                AddressInput.Background = new SolidColorBrush(Color.FromRgb(197, 247, 162));
            }
            else
            {
                AddressInput.Background = new SolidColorBrush(Color.FromRgb(251, 137, 137));
            }
        }

        //Sets the Selected for edit or delete
        private void SelectedCostumer(object sender, SelectionChangedEventArgs e)
        {
            CostumerController.GetInstance().SetCurrentCostumer(DisplayArea.SelectedItem as Costumer);
        }

    }
}
