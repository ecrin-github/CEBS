using CEBS.Contracts.Requests.Audit.v1;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.Audit.DTO.v1;
using CEBS.Interfaces.Audit.Services;

namespace CEBS.Services.Audit;

public class RmsAuditService : IRmsAuditService
{
    public async Task<BaseResponse<AuditDto>> CreateRmsAuditRecordChange(AuditRequest auditRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<AuditDto>> GetRmsTableAuditHistory(string tableName)
    {
        throw new NotImplementedException();
    }
}