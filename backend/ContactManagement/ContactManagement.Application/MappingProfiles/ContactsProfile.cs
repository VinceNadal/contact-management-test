using AutoMapper;
using ContactManagement.Application.Dtos;
using ContactManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Application.MappingProfiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>();
            CreateMap<CreateContactDto, Contact>();
        }
    }
}
