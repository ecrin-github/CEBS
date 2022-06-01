using CEBS.Contracts.Responses;
using CEBS.Models.Context.Rms;

namespace CEBS.Interfaces.Context.Repositories;

public interface IRmsContextRepository
{
    Task<BaseResponse<AccessPrereqType>> GetAccessPrereqTypes();
    Task<BaseResponse<AccessPrereqType>> GetAccessPrereqType(int id);
        
    Task<BaseResponse<CheckStatusType>> GetCheckStatusTypes();
    Task<BaseResponse<CheckStatusType>> GetCheckStatusType(int id);
        
    Task<BaseResponse<DtpStatusType>> GetDtpStatusTypes();
    Task<BaseResponse<DtpStatusType>> GetDtpStatusType(int id);
        
    Task<BaseResponse<DupStatusType>> GetDupStatusTypes();
    Task<BaseResponse<DupStatusType>> GetDupStatusType(int id);
        
    Task<BaseResponse<LegalStatusType>> GetLegalStatusTypes();
    Task<BaseResponse<LegalStatusType>> GetLegalStatusType(int id);
        
    Task<BaseResponse<RepoAccessType>> GetRepoAccessTypes();
    Task<BaseResponse<RepoAccessType>> GetRepoAccessType(int id);
}