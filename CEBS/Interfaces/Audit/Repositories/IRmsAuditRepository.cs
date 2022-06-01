using CEBS.Contracts.Responses;
using CEBS.Models.Audit;

namespace CEBS.Interfaces.Audit.Repositories;

public interface IRmsAuditRepository
{
    Task<BaseResponse<RmsRecordChange>> CreateRmsAuditRecordChange(RmsRecordChange rmsRecordChange);
    Task<BaseResponse<RmsRecordChange>> GetRmsTableAuditHistory(string tableName);
}