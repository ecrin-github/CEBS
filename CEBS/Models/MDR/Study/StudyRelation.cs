using CEBS.Models.MDR.Common;
using Nest;

namespace CEBS.Models.MDR.Study;

public class StudyRelation
{
    [Number(Name = "id")]
    public int? Id { get; set; }
        
    [Object]
    [PropertyName("relationship_type")]
    public RelationType? RelationshipType { get; set; }
        
    [Number(Name = "target_study_id")]
    public int? TargetStudyId { get; set; }
}