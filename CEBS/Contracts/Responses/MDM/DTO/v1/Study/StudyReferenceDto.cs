namespace CEBS.Contracts.Responses.MDM.DTO.v1.Study;

public class StudyReferenceDto
{
    public int? Id { get; set; }
        
    public string? SdSid { get; set; }
        
    public string? Pmid { get; set; }
        
    public string? Citation { get; set; }
        
    public string? Doi { get; set; }
        
    public string? Comments { get; set; }
        
    public DateTime? CreatedOn { get; set; }
}