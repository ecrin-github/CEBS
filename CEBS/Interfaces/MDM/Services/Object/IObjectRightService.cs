using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectRightService
{
    // Object rights
    Task<BaseResponse<ObjectRightDto>> GetObjectRights(string sdOid);
    Task<BaseResponse<ObjectRightDto>> GetObjectRight(int id);
    Task<BaseResponse<ObjectRightDto>> CreateObjectRight(ObjectRightDto objectRightDto);
    Task<BaseResponse<ObjectRightDto>> UpdateObjectRight(ObjectRightDto objectRightDto);
    Task<int> DeleteObjectRight(int id);
    Task<int> DeleteAllObjectRights(string sdOid);
}