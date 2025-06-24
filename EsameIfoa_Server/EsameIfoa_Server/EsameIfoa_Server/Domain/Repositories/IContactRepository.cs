using EsameIfoa_Server.Domain.Models;

namespace EsameIfoa_Server.Domain.Repositories
{
  public interface IContactRepository
  {
    Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken);
    Task <bool> AddAsync(Contact contact, CancellationToken cancellationToken);
  }
}
