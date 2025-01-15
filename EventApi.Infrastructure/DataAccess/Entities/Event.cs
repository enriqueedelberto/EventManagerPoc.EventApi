using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApi.Infrastructure.DataAccess.Entities;

[Table("Events")]
public class Event
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Description { get; set; }

    [Required] 
    public DateTime Date { get; set; }

    [Required] 
    public string Time { get; set; }

    [Required]
    public string Type { get; set; }

    public string City { get; set; }
    public string Country { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Language { get; set; }

}
