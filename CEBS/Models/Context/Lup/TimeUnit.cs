using System.ComponentModel.DataAnnotations.Schema;

namespace CEBS.Models.Context.Lup;

[Table("time_units", Schema = "lup")]
public class TimeUnit
{
    [Column("id")]
    public int Id { get; set; }
        
    [Column("name")]
    public string Name { get; set; }
        
    [Column("description")]
    public string Description { get; set; }
        
    [Column("use_in_data_entry")]
    public bool? UseInDataEntry { get; set; }
        
    [Column("list_order")]
    public int ListOrder { get; set; }
        
    [Column("source")]
    public string Source { get; set; }
        
    [Column("date_added", TypeName = "Date")]
    public DateTime DateAdded { get; set; }
}