namespace CEBS.Contracts.Responses.RMS.DTO.v1;

public class DupPrereqDto
{
    public int Id { get; set; }
        
    public int DupId { get; set; }
        
    public string? ObjectId { get; set; }
        
    public int? PreRequisiteId { get; set; }
        
    public DateTime? PrerequisiteMet { get; set; }
        
    public string? MetNotes { get; set; }
        
    public DateTime? CreatedOn { get; set; }
}