using AutoMapper;
using ContactManagement.Application.Contracts.Persistence;
using ContactManagement.Application.Contracts.Services;
using ContactManagement.Application.Dtos;
using ContactManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactManagement.Application.Services
{
    public class JsonFileContactsService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;
        public JsonFileContactsService(IMapper mapper, IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }

        public async Task<ContactDto> AddContactAsync(CreateContactDto createContactDto)
        {
            var contact = mapper.Map<Contact>(createContactDto);
            contact.Id = Guid.NewGuid();
            contactRepository.AddContact(contact);
            await contactRepository.SaveChanges();

            return mapper.Map<ContactDto>(contact);
        }

        public async Task DeleteContactAsync(Guid contactId)
        {
            contactRepository.DeleteContact(contactId);
            await contactRepository.SaveChanges();
        }

        public List<ContactDto> GetAllContacts()
        {
            var contacts = contactRepository.GetAllContacts();
            
            return mapper.Map<List<ContactDto>>(contacts);
        }

        public ContactDto? GetContactById(Guid contactId)
        {
            var contact = contactRepository.GetContactById(contactId);
            return mapper.Map<ContactDto>(contact);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var contactToUpdate = mapper.Map<Contact>(updateContactDto);
            contactRepository.UpdateContact(contactToUpdate);
            await contactRepository.SaveChanges();
        }
    }
}
