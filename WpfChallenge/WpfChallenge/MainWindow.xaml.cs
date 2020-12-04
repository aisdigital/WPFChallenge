using System.Windows;

using WpfChallenge.Controller;
using WpfChallenge.Model;

namespace WpfChallenge
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CostumerController costumerControl = new CostumerController();

        public MainWindow()
        {
            InitializeComponent();
            reloadGrid();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (this.lstCostumer.SelectedItems.Count > 0)
                {
                    Costumer costumerEdit = (Costumer)this.lstCostumer.SelectedItems[0];
                    costumerEdit.Name = txtName.Text;
                    costumerEdit.Email = txtEmail.Text;
                    costumerEdit.Phone = txtPhone.Text;
                    costumerEdit.Address = txtAddress.Text;
                    costumerControl.editCostumer(costumerEdit);
                    reloadGrid();
                }
                else
                {
                    Costumer costumer = new Costumer()
                    {
                        Name = txtName.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        Address = txtAddress.Text,
                    };
                    costumerControl.saveCostumer(costumer);
                    reloadGrid();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.lstCostumer.SelectedItems.Count > 0)
            {
                MessageBoxResult  result =   MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);

                if(result == MessageBoxResult.Yes)
                {
                    Costumer costumer = (Costumer)this.lstCostumer.SelectedItems[0];
                    costumerControl.deleteCostumer(int.Parse(costumer.id));
                    reloadGrid();
                }
                else
                {
                    return;
                }
            }else
            {
                MessageBox.Show("Select an Item!");
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            reloadGrid();
        }

        private void lstCostumer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {        
            if (this.lstCostumer.SelectedItems.Count > 0)
            {
                
                Costumer costumer = (Costumer)this.lstCostumer.SelectedItems[0];
                this.txtName.Text = costumer.Name;
                this.txtEmail.Text = costumer.Email;
                this.txtPhone.Text = costumer.Phone;
                this.txtAddress.Text = costumer.Address;
                if (btnDelete != null)
                {
                    btnDelete.IsEnabled = true;
                }
                if (btnNew != null)
                {
                    btnNew.IsEnabled = true;
                }
                if (lblControl != null)
                {
                    lblControl.Content = "Edit Item";
                }
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name Field is Required!");
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("E-mail Field is Required!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Phone Field is Required!");
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Address Field is Required!");
                return false;
            }
            return true;
        }

        private void reloadGrid()
        {
            this.lstCostumer.ItemsSource = new ViewModel.CostumerViewModel();
            this.lstCostumer.SelectedItem = null;
            btnDelete.IsEnabled = false;
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            lblControl.Content = "New Item";
            btnNew.IsEnabled = false;
        }
    }
    
}
