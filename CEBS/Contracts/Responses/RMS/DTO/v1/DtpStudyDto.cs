namespace CEBS.Contracts.Responses.RMS.DTO.v1;

public class DtpStudyDto
{
    public int Id { get; set; }
        
    public int DtpId { get; set; }
        
    public string? StudyId { get; set; }
        
    public int? MdCheckStatusId { get; set; }
        
    public DateTime? MdCheckDate { get; set; }
        
    public int? MdCheckBy { get; set; }
        
    public DateTime? CreatedOn { get; set; }
}