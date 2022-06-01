using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectRightService : IObjectRightService
{
    public async Task<BaseResponse<ObjectRightDto>> GetObjectRights(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectRightDto>> GetObjectRight(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectRightDto>> CreateObjectRight(ObjectRightDto objectRightDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectRightDto>> UpdateObjectRight(ObjectRightDto objectRightDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectRight(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectRights(string sdOid)
    {
        throw new NotImplementedException();
    }
}