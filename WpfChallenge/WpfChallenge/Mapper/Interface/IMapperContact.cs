using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfChallenge.Domain.Entities;
using WpfChallenge;
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
