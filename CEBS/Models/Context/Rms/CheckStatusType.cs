using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEBS.Models.Context.Rms;

[Table("check_status_types", Schema = "rms")]
public class CheckStatusType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
        
    [Column("name")]
    public string? Name { get; set; }
        
    [Column("description")]
    public string? Description { get; set; }
        
    [Column("list_order")]
    public int? ListOrder { get; set; }
        
    [Column("created_on")]
    public DateTime? CreatedOn { get; set; }
}