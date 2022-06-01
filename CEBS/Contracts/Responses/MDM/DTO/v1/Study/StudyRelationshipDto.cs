namespace CEBS.Contracts.Responses.MDM.DTO.v1.Study;

public class StudyRelationshipDto
{
    public int? Id { get; set; }
        
    public string? SdSid { get; set; }
        
    public int? RelationshipTypeId { get; set; }
        
    public string? TargetSdSid { get; set; }
        
    public DateTime? CreatedOn { get; set; }
}