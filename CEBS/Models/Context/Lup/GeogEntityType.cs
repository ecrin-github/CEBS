using System.ComponentModel.DataAnnotations.Schema;

namespace CEBS.Models.Context.Lup;

[Table("geog_entity_types", Schema = "lup")]
public class GeogEntityType
{
    [Column("id")]
    public int Id { get; set; }
        
    [Column("name")]
    public string Name { get; set; }
        
    [Column("description")]
    public string Description { get; set; }
        
    [Column("list_order")]
    public int ListOrder { get; set; }
}