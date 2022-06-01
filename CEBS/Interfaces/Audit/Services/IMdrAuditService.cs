using CEBS.Contracts.Requests.Audit.v1;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.Audit.DTO.v1;

namespace CEBS.Interfaces.Audit.Services;

public interface IMdrAuditService
{
    Task<BaseResponse<AuditDto>> CreateMdrAuditRecordChange(AuditRequest auditRequestDto);
    Task<BaseResponse<AuditDto>> GetMdrTableAuditHistory(string tableName);
}