using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApi.Infrastructure.DataAccess.Entities;

[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Location { get; set; }

    [Required]
    [MaxLength(20)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }
    public DateTimeOffset Birthday { get; set; }
}
