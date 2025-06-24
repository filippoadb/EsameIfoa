using EsameIfoa_Server.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EsameIfoa_Server.Infrastructure.Data;

public class DataContext:  DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }
  public DbSet<Contact> Contact { get; set; }
}

