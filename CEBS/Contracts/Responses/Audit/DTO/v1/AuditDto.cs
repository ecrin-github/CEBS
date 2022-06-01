namespace CEBS.Contracts.Responses.Audit.DTO.v1;

public class AuditDto
{
    public int Id { get; set; }

    public string? TableName { get; set; }
    
    public DateTime ChangeTime { get; set; }

    public string? UserName { get; set; }

    public string? Prior { get; set; }

    public string? Post { get; set; }
}