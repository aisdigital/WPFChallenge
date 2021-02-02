using System;

namespace WpfChallenge.Domain.Entities
{
	public class Contact
	{
		public int ContactId { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public DateTime RegisterDate { get; set; }

		#region Validations

		public bool IsNotNullValidation(Contact contact)
		{
			if (!string.IsNullOrEmpty(contact.Name) &&
				!string.IsNullOrEmpty(contact.Phone) &&
				!string.IsNullOrEmpty(contact.Email) &&
				!string.IsNullOrEmpty(contact.Address))
				return true;
			else
				return false;
		}

		public bool NumbersOfCharacterValidation(Contact contact)
		{
			if (this.Name.Length < 150 &&
				this.Phone.Length < 20 &&
				this.Email.Length < 100 &&
				this.Address.Length < 250)
				return true;
			else
				return false;
		}

		public bool EmailValidation(string Email)
		{
			this.Email = Email;

			if (this.Email.Contains("@") && this.Email.Contains("."))
				return true;
			else
				return false;
		}

		#endregion Validations
	}
}