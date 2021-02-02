using System.Collections.Generic;
using WpfChallenge.Domain.Entities;
using WpfChallenge.DTO;

namespace WpfChallenge.Mapper.Interface
{
	public interface IMapperContact
	{
		Contact MapperDtoToEntity(ContactDTO contactDTO);

		IEnumerable<ContactDTO> MapperListContactsDto(IEnumerable<Contact> contacts);

		ContactDTO MapperEntityToDto(Contact contact);
	}
}