using Nest;

namespace CEBS.Models.MDR.Object;

public class ManagingOrg
{
    [Number(Name = "id")]
    public int? Id { get; set; }
        
    [Text(Name = "name")]
    public string? Name { get; set; }
        
    [Text(Name = "ror_id")]
    public string? RorId { get; set; }
}