using AutoMapper;
using EsameIfoa_Server.Domain.Models;
using EsameIfoa_Server.Domain.Repositories;
using EsameIfoa_Server.Domain.Services;
using EsameIfoa_Server.Dto;

namespace EsameIfoa_Server.Infrastructure.Services
{
  public class ContactService(IContactRepository contactRepository , IMapper mapper) : IContactService
  {
    public async Task<bool> AddAsync(ContactDto contact, CancellationToken cancellationToken)
    {
      Contact contacts = mapper.Map<Contact>(contact);
      return await contactRepository.AddAsync(contacts,cancellationToken);
    }

    public async Task<IEnumerable<ContactDto>> GetAllAsync(CancellationToken cancellationToken)
    {
      IEnumerable<ContactDto> contact= mapper.Map<IEnumerable<ContactDto>>(await contactRepository.GetAllAsync(cancellationToken));
      return contact;
    }
  }
}
