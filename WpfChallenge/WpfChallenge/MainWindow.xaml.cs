using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
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
using WpfChallenge.Domain.Entities;
using WpfChallenge.DTO;
using WpfChallenge.Infrastructure.Data.Repositories;
using WpfChallenge.Mapper;

namespace WpfChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContactDTO contactDTOUpdate = new ContactDTO();
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly ContactRepository _contactRepository = new ContactRepository();
        private readonly MapperContact mapperContact = new MapperContact();
        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhone.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains("."))
                {
                    ContactDTO contactDTO = new ContactDTO()
                    {
                        Name = txtName.Text,
                        Phone = txtPhone.Text,
                        Email = txtEmail.Text,
                        Address = txtAddress.Text
                    };

                    var contactDomain = mapperContact.MapperDtoToEntity(contactDTO);
                    _contactRepository.Add(contactDomain);

                    ContactList();
                    TextboxCleaner();
                }
                else 
                {
                    MessageBoxResult result = MessageBox.Show("All fields are required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else 
            {
                MessageBoxResult result = MessageBox.Show("All fields are required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ContactList();
            dgvContacts.IsReadOnly = true;
        }

        private void ContactList() 
        {
            var contactsDTO = mapperContact.MapperListContactsDto(_contactRepository.GetAll());
            dgvContacts.ItemsSource = contactsDTO;
        }

        private void btEdit_Click(object sender, RoutedEventArgs e) 
        {
            contactDTOUpdate = dgvContacts.SelectedItem as ContactDTO;

            txtName.Text = contactDTOUpdate.Name;
            txtPhone.Text = contactDTOUpdate.Phone;
            txtEmail.Text = contactDTOUpdate.Email;
            txtAddress.Text = contactDTOUpdate.Address;

            btnUpdate.IsEnabled = true;
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            contactDTOUpdate = dgvContacts.SelectedItem as ContactDTO;

            if (MessageBox.Show("Do you want to remove this data", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                var contactDomain = _contactRepository.GetById(contactDTOUpdate.ContactId);
                _contactRepository.Remove(contactDomain);

                ContactList();
                TextboxCleaner();
            }
            
        }

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
            var contactDomain = _contactRepository.GetById(contactDTOUpdate.ContactId);

            contactDomain.Name = txtName.Text;
            contactDomain.Phone = txtPhone.Text;
            contactDomain.Email = txtEmail.Text;
            contactDomain.Address = txtAddress.Text;

            _contactRepository.Update(contactDomain);
            ContactList();
            TextboxCleaner();
            btnUpdate.IsEnabled = false;
        }

        private void TextboxCleaner() 
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }
    }
}
