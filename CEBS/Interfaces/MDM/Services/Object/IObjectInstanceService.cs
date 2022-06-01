using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectInstanceService
{
    // Object instances
    Task<BaseResponse<ObjectInstanceDto>> GetObjectInstances(string sdOid);
    Task<BaseResponse<ObjectInstanceDto>> GetObjectInstance(int id);
    Task<BaseResponse<ObjectInstanceDto>> CreateObjectInstance(ObjectInstanceDto objectInstanceDto);
    Task<BaseResponse<ObjectInstanceDto>> UpdateObjectInstance(ObjectInstanceDto objectInstanceDto);
    Task<int> DeleteObjectInstance(int id);
    Task<int> DeleteAllObjectInstances(string sdOid);
}