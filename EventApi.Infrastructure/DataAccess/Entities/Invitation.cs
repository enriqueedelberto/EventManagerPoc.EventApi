using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventApi.Infrastructure.DataAccess.Entities;

[Table("Invitations")]
public class Invitation
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int IdEvent { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string User { get; set; }

    [Required]
    [MaxLength(100)]
    public string Status { get; set; }  
    public DateTime Date { get; set; }
}
