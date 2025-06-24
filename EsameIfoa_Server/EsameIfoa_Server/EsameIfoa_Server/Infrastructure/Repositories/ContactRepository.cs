using EsameIfoa_Server.Domain.Models;
using EsameIfoa_Server.Domain.Repositories;
using EsameIfoa_Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EsameIfoa_Server.Infrastructure.Repositories
{
  public class ContactRepository(DataContext context) : IContactRepository
  {
    public async Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken)

    {
      return await context.Contact.ToListAsync(cancellationToken);
    }


    public async Task<bool> AddAsync(Contact contact, CancellationToken cancellationToken)

    {

      await context.Contact.AddAsync(contact);

      await context.SaveChangesAsync();

      return true;

    }
  }
}
