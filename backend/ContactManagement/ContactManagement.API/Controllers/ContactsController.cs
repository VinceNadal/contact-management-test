using ContactManagement.Application.Contracts.Services;
using ContactManagement.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public ActionResult<List<ContactDto>> GetAllContacts()
        {
            var contacts = contactService.GetAllContacts();
            return Ok(contacts);
        }


        [HttpGet("{contactId}", Name= "GetContactById")]
        public ActionResult<ContactDto> GetContactById(Guid contactId)
        {
            var contact = contactService.GetContactById(contactId);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<ContactDto>> AddContact(CreateContactDto createContactDto)
        {
            var contact = await contactService.AddContactAsync(createContactDto);
            return CreatedAtRoute(nameof(GetContactById), new { contactId = contact.Id }, contact);
        }

        [HttpPut]
        public ActionResult<ContactDto> UpdateContact(UpdateContactDto updateContactDto)
        {
            var contact = contactService.UpdateContactAsync(updateContactDto);
            return Ok(contact);
        }

        [HttpDelete("{contactId}")]
        public async Task<ActionResult> DeleteContact(Guid contactId)
        {
            await contactService.DeleteContactAsync(contactId);
            return NoContent();
        }
    }

}

