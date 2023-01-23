using ContactManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Application.Contracts.Services
{
    public interface IContactService
    {
        List<ContactDto> GetAllContacts();
        ContactDto? GetContactById(Guid contactId);
        Task<ContactDto> AddContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(Guid contactId);
    }
}
