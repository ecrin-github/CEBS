namespace CEBS.Contracts.Requests.Audit.v1;

public class AuditRequest
{
    public string? UserName { get; set; } = string.Empty;
    public string? TableName { get; set; } = string.Empty;
}