using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectTitleService
{
    // Object titles
    Task<BaseResponse<ObjectTitleDto>> GetObjectTitles(string sdOid);
    Task<BaseResponse<ObjectTitleDto>> GetObjectTitle(int id);
    Task<BaseResponse<ObjectTitleDto>> CreateObjectTitle(ObjectTitleDto objectTitleDto);
    Task<BaseResponse<ObjectTitleDto>> UpdateObjectTitle(ObjectTitleDto objectTitleDto);
    Task<int> DeleteObjectTitle(int id);
    Task<int> DeleteAllObjectTitles(string sdOid);
}