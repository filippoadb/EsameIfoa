using AutoMapper;
using EsameIfoa_Server.Domain.Models;
using EsameIfoa_Server.Dto;

namespace EsameIfoa_Server.Mapping
{
  public class ContactProfile : Profile
  {
    public ContactProfile() {
    CreateMap<ContactDto, Contact>().ReverseMap();
    }
  }
}
