using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Entities;
using WpfChallenge.DTO;
using WpfChallenge.Mapper.Interface;

namespace WpfChallenge.Mapper
{
	public class MapperContact : IMapperContact
	{
		public Contact MapperDtoToEntity(ContactDTO contactDTO)
		{
			var contact = new Contact()
			{
				ContactId = contactDTO.ContactId,
				Name = contactDTO.Name,
				Phone = contactDTO.Phone,
				Email = contactDTO.Email,
				Address = contactDTO.Address
			};

			return contact;
		}

		public ContactDTO MapperEntityToDto(Contact contact)
		{
			var contactDTO = new ContactDTO()
			{
				ContactId = contact.ContactId,
				Name = contact.Name,
				Phone = contact.Phone,
				Email = contact.Email,
				Address = contact.Address
			};

			return contactDTO;
		}

		public IEnumerable<ContactDTO> MapperListContactsDto(IEnumerable<Contact> contacts)
		{
			var dto = contacts.Select(c => new ContactDTO()
			{
				ContactId = c.ContactId,
				Name = c.Name,
				Phone = c.Phone,
				Email = c.Email,
				Address = c.Address
			});

			return dto;
		}
	}
}
