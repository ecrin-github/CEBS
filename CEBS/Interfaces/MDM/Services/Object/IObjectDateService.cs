using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectDateService
{
    // Object dates
    Task<BaseResponse<ObjectDateDto>> GetObjectDates(string sdOid);
    Task<BaseResponse<ObjectDateDto>> GetObjectDate(int id);
    Task<BaseResponse<ObjectDateDto>> CreateObjectDate(ObjectDateDto objectDateDto);
    Task<BaseResponse<ObjectDateDto>> UpdateObjectDate(ObjectDateDto objectDateDto);
    Task<int> DeleteObjectDate(int id);
    Task<int> DeleteAllObjectDates(string sdOid);
}