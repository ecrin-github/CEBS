using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectInstanceService : IObjectInstanceService
{
    public async Task<BaseResponse<ObjectInstanceDto>> GetObjectInstances(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectInstanceDto>> GetObjectInstance(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectInstanceDto>> CreateObjectInstance(ObjectInstanceDto objectInstanceDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectInstanceDto>> UpdateObjectInstance(ObjectInstanceDto objectInstanceDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectInstance(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectInstances(string sdOid)
    {
        throw new NotImplementedException();
    }
}