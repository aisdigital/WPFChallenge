using System;
using System.Collections.Generic;
using System.Text;
using WpfChallenge.Domain.Entities;
using WpfChallenge.Infrastructure.Data.Repositories;
using Xunit;

namespace WpfChallenge.Tests.Data
{
	public class DataTests
	{
		private readonly ContactRepository _contactRepository = new ContactRepository();

		Contact contact = new Contact()
		{
			Address = "Vila Andrade Morumbi",
			Email = "ads.paulocesar@gmail.com",
			Name = "Paulo Cesar",
			Phone = "13997612717"
		};

		[Fact]
		public void AddContactTest()
		{
			var expected = true;

			var result = _contactRepository.Add(contact);

			Assert.Equal(expected, result);
		}

		[Fact]
		public void UpdateContactTest()
		{
			contact.ContactId = 2;

			var expected = true;

			var result = _contactRepository.Update(contact);

			Assert.Equal(expected, result);
		}

		[Fact]
		public void RemoveContactTest()
		{
			var expected = true;

			var contactRemove = _contactRepository.GetById(2);
			var result = _contactRepository.Remove(contactRemove);

			Assert.Equal(expected, result);
		}
	}
}
