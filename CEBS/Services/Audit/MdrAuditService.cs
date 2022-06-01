using CEBS.Contracts.Requests.Audit.v1;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.Audit.DTO.v1;
using CEBS.Interfaces.Audit.Services;

namespace CEBS.Services.Audit;

public class MdrAuditService : IMdrAuditService
{
    public async Task<BaseResponse<AuditDto>> CreateMdrAuditRecordChange(AuditRequest auditRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<AuditDto>> GetMdrTableAuditHistory(string tableName)
    {
        throw new NotImplementedException();
    }
}