using CEBS.Contracts.Responses;
using CEBS.Interfaces.Audit.Repositories;
using CEBS.Models.Audit;

namespace CEBS.Repositories.Audit;

public class RmsAuditRepository : IRmsAuditRepository
{
    public async Task<BaseResponse<RmsRecordChange>> CreateRmsAuditRecordChange(RmsRecordChange rmsRecordChange)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<RmsRecordChange>> GetRmsTableAuditHistory(string tableName)
    {
        throw new NotImplementedException();
    }
}