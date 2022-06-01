using CEBS.Contracts.Responses;
using CEBS.Interfaces.Audit.Repositories;
using CEBS.Models.Audit;

namespace CEBS.Repositories.Audit;

public class MdrAuditRepository : IMdrAuditRepository
{
    public async Task<BaseResponse<MdrRecordChange>> CreateMdrAuditRecordChange(MdrRecordChange mdrRecordChange)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<MdrRecordChange>> GetMdrTableAuditHistory(string tableName)
    {
        throw new NotImplementedException();
    }
}