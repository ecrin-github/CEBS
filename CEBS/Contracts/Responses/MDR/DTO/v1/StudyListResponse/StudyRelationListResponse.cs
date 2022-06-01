namespace CEBS.Contracts.Responses.MDR.DTO.v1.StudyListResponse;

public class StudyRelationListResponse
{
    public int? Id { get; set; }
        
    public string? RelationshipType { get; set; }
        
    public string? TargetStudyId { get; set; }
}