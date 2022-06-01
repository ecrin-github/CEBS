namespace CEBS.Contracts.Responses.MDM.DTO.v1.Study;

public class StudyFeatureDto
{
    public int? Id { get; set; }
        
    public string? SdSid { get; set; }
        
    public int? FeatureTypeId { get; set; }

    public int? FeatureValueId { get; set; }
        
    public DateTime? CreatedOn { get; set; }
}