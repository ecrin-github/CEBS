using CEBS.Contracts.Responses;
using CEBS.Models.Audit;

namespace CEBS.Interfaces.Audit.Repositories;

public interface IMdrAuditRepository
{
    Task<BaseResponse<MdrRecordChange>> CreateMdrAuditRecordChange(MdrRecordChange mdrRecordChange);
    Task<BaseResponse<MdrRecordChange>> GetMdrTableAuditHistory(string tableName);
}