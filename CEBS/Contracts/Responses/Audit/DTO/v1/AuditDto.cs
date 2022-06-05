namespace CEBS.Contracts.Responses.Audit.DTO.v1;

public class AuditDto
{
    public int Id { get; set; }

    public string? TableName { get; set; } = string.Empty;
    
    public DateTime ChangeTime { get; set; }

    public string? UserName { get; set; } = string.Empty;

    public string? Prior { get; set; } = string.Empty;

    public string? Post { get; set; } = string.Empty;
}