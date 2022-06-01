using Nest;

namespace CEBS.Models.MDR.Common;

public class RelationType
{
    [Number(Name = "id")]
    public int? Id { get; set; }
        
    [Text(Name = "name")]
    public string? Name { get; set; }
}