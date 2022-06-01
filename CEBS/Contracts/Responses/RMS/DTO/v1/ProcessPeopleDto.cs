namespace CEBS.Contracts.Responses.RMS.DTO.v1;

public class ProcessPeopleDto
{
    public int Id { get; set; }
        
    public int? ProcessType { get; set; }
        
    public int? ProcessId { get; set; }
        
    public int? PersonId { get; set; }
        
    public bool? IsAUser { get; set; }
        
    public string? Notes { get; set; }
        
    public DateTime? CreatedOn { get; set; }
}