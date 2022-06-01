namespace CEBS.Contracts.Responses.RMS.DTO.v1;

public class ProcessNoteDto
{
    public int Id { get; set; }
        
    public int? ProcessType { get; set; }
        
    public int? ProcessId { get; set; }
        
    public string? Text { get; set; }
        
    public int? Author { get; set; }
        
    public DateTime? CreatedOn { get; set; }
}