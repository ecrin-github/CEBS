using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectDescriptionService
{
    // Object descriptions
    Task<BaseResponse<ObjectDescriptionDto>> GetObjectDescriptions(string sdOid);
    Task<BaseResponse<ObjectDescriptionDto>> GetObjectDescription(int id);
    Task<BaseResponse<ObjectDescriptionDto>> CreateObjectDescription(ObjectDescriptionDto objectDescriptionDto);
    Task<BaseResponse<ObjectDescriptionDto>> UpdateObjectDescription(ObjectDescriptionDto objectDescriptionDto);
    Task<int> DeleteObjectDescription(int id);
    Task<int> DeleteAllObjectDescriptions(string sdOid);
}