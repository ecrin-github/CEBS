using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectDescriptionService : IObjectDescriptionService
{
    public async Task<BaseResponse<ObjectDescriptionDto>> GetObjectDescriptions(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDescriptionDto>> GetObjectDescription(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDescriptionDto>> CreateObjectDescription(ObjectDescriptionDto objectDescriptionDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDescriptionDto>> UpdateObjectDescription(ObjectDescriptionDto objectDescriptionDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectDescription(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectDescriptions(string sdOid)
    {
        throw new NotImplementedException();
    }
}