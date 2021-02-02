using System.Windows;
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
		private readonly ContactRepository _contactRepository = new ContactRepository();
		private readonly MapperContact mapperContact = new MapperContact();
		private ContactDTO contactDTOUpdate = new ContactDTO();

		public MainWindow()
		{
			InitializeComponent();
		}

		#region WindowLoaded
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.ContactList();
			dgvContacts.IsReadOnly = true;
		}

		#endregion

		#region ActionSave
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
					MessageBox.Show("Please input a valid E-mail", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else
				MessageBox.Show("All fields are required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		#endregion

		#region ActionEdit
		private void btEdit_Click(object sender, RoutedEventArgs e)
		{
			contactDTOUpdate = dgvContacts.SelectedItem as ContactDTO;

			if (contactDTOUpdate != null)
			{
				txtName.Text = contactDTOUpdate.Name;
				txtPhone.Text = contactDTOUpdate.Phone;
				txtEmail.Text = contactDTOUpdate.Email;
				txtAddress.Text = contactDTOUpdate.Address;

				btnUpdate.IsEnabled = true;
			}
		}

		#endregion

		#region ActionUpdate
		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			var contactDomain = _contactRepository.GetById(contactDTOUpdate.ContactId);
			if (contactDomain != null)
			{
				contactDomain.Name = txtName.Text;
				contactDomain.Phone = txtPhone.Text;
				contactDomain.Email = txtEmail.Text;
				contactDomain.Address = txtAddress.Text;

				_contactRepository.Update(contactDomain);
				ContactList();
				TextboxCleaner();
				btnUpdate.IsEnabled = false;
			}
		}

		#endregion

		#region ActionRemove
		private void btRemove_Click(object sender, RoutedEventArgs e)
		{
			contactDTOUpdate = dgvContacts.SelectedItem as ContactDTO;

			if (contactDTOUpdate != null)
			{
				if (MessageBox.Show("Do you want to remove this data", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					var contactDomain = _contactRepository.GetById(contactDTOUpdate.ContactId);

					if (contactDomain != null)
						_contactRepository.Remove(contactDomain);

					ContactList();
					TextboxCleaner();
				}
			}
		}

		#endregion

		#region AuxiliaryMethods
		private void ContactList()
		{
			var contactsDTO = mapperContact.MapperListContactsDto(_contactRepository.GetAll());

			if (contactsDTO != null)
				dgvContacts.ItemsSource = contactsDTO;
		}

		private void TextboxCleaner()
		{
			txtName.Text = "";
			txtPhone.Text = "";
			txtEmail.Text = "";
			txtAddress.Text = "";
		}

		#endregion
	}
}