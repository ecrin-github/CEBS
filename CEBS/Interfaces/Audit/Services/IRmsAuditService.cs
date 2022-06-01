using CEBS.Contracts.Requests.Audit.v1;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.Audit.DTO.v1;

namespace CEBS.Interfaces.Audit.Services;

public interface IRmsAuditService
{
    Task<BaseResponse<AuditDto>> CreateRmsAuditRecordChange(AuditRequest auditRequestDto);
    Task<BaseResponse<AuditDto>> GetRmsTableAuditHistory(string tableName);
}