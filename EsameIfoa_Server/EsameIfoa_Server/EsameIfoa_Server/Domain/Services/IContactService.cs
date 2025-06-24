using EsameIfoa_Server.Domain.Models;
using EsameIfoa_Server.Dto;

namespace EsameIfoa_Server.Domain.Services;

public interface IContactService
{
  Task<IEnumerable<ContactDto>> GetAllAsync(CancellationToken cancellationToken);
  Task <bool> AddAsync(ContactDto contact, CancellationToken cancellationToken);
}
