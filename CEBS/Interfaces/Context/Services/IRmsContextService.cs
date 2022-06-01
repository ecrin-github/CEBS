using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.Context.DTO.v1;

namespace CEBS.Interfaces.Context.Services;

public interface IRmsContextService
{
    Task<BaseResponse<ContextDto>> GetAccessPrereqTypes();
    Task<BaseResponse<ContextDto>> GetAccessPrereqType(int id);
        
    Task<BaseResponse<ContextDto>> GetCheckStatusTypes();
    Task<BaseResponse<ContextDto>> GetCheckStatusType(int id);
        
    Task<BaseResponse<ContextDto>> GetDtpStatusTypes();
    Task<BaseResponse<ContextDto>> GetDtpStatusType(int id);
        
    Task<BaseResponse<ContextDto>> GetDupStatusTypes();
    Task<BaseResponse<ContextDto>> GetDupStatusType(int id);
        
    Task<BaseResponse<ContextDto>> GetLegalStatusTypes();
    Task<BaseResponse<ContextDto>> GetLegalStatusType(int id);
        
    Task<BaseResponse<ContextDto>> GetRepoAccessTypes();
    Task<BaseResponse<ContextDto>> GetRepoAccessType(int id);
}