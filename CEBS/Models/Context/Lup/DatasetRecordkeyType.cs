using System.ComponentModel.DataAnnotations.Schema;

namespace CEBS.Models.Context.Lup;

[Table("dataset_recordkey_types", Schema = "lup")]
public class DatasetRecordkeyType
{
    [Column("id")]
    public int Id { get; set; }
        
    [Column("name")]
    public string Name { get; set; }
        
    [Column("description")]
    public string Description { get; set; }
        
    [Column("list_order")]
    public int ListOrder { get; set; }
        
    [Column("source")]
    public string Source { get; set; }
        
    [Column("date_added", TypeName = "Date")]
    public DateTime DateAdded { get; set; }
}