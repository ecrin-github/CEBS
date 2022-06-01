using CEBS.Models.MDR.Common;
using Nest;

namespace CEBS.Models.MDR.Object;

public class ObjectRelationship
{
    [Number(Name = "id")]
    public int? Id { get; set; }
        
    [Object]
    [PropertyName("relationship_type")]
    public RelationType? RelationshipType { get; set; }
        
    [Number(Name = "target_object_id")]
    public int? TargetObjectId { get; set; }
}