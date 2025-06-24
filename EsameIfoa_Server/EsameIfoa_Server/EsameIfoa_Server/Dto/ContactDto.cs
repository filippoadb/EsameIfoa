using System.ComponentModel.DataAnnotations;

namespace EsameIfoa_Server.Dto
{
  public class ContactDto
  {

    public int Id { get; set; }

    public required string FullName { get; set; }
    public required string Email { get; set; }

    public required string Phone { get; set; }
    public required string Department { get; set; }

  }
}
