using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;
[Table("constacts")]
public class ContactEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(length:20)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(length:20)]
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    [Column("phone")]
    public string PhoneNumber { get; set; }
    
    public DateOnly Birth { get; set; }
    
    public Category Category { get; set; }
    
    public DateTime Created { get; set; }

    public int OrganizationId { get; set; }

    public OrganizationEntity? Organization { get; set; }
}