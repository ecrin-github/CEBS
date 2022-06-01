using Nest;

namespace CEBS.Models.MDR.Object;

public class ObjectType
{
    [Number(Name = "id")]
    public int? Id { get; set; }
        
    [Text(Name = "name")]
    public string? Name { get; set; }
}