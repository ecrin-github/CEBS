namespace CEBS.Contracts.Responses.RMS.DTO.v1;

public class AccessPrereqDto
{
    public int Id { get; set; }
        
    public int? ObjectId { get; set; }
        
    public int? PreRequisiteId { get; set; }
        
    public string? PreRequisiteNotes { get; set; }
        
    public DateTime? CreatedOn { get; set; }
}