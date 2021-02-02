using System;
using System.Collections.Generic;
using System.Text;
using WpfChallenge.Domain.Entities;
using Xunit;

namespace WpfChallenge.Tests.Domain
{
	public class DomainTests
	{
		private Contact _contact = new Contact()
		{
			Address = "Vila Andrade Morumbi",
			Email = "ads.paulocesar@gmail.com",
			Name = "Paulo Cesar",
			Phone = "13997612717"
		};

		[Fact]
		public void CharactersValidation()
		{
			var expected = true;

			var result = _contact.NumbersOfCharacterValidation(_contact);

			Assert.Equal(expected, result);
		}

		[Fact]
		public void IsNullValidation()
		{
			var expected = true;

			var result = _contact.IsNotNullValidation(_contact);

			Assert.Equal(expected, result);
		}

		[Fact]
		public void EmailValidation()
		{
			var email = "ads.paulocesar@gmail.com";

			var expected = true;

			var result = _contact.EmailValidation(email);

			Assert.Equal(expected, result);
		}
	}
}
