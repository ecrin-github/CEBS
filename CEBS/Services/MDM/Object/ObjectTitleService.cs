using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectTitleService : IObjectTitleService
{
    public async Task<BaseResponse<ObjectTitleDto>> GetObjectTitles(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectTitleDto>> GetObjectTitle(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectTitleDto>> CreateObjectTitle(ObjectTitleDto objectTitleDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectTitleDto>> UpdateObjectTitle(ObjectTitleDto objectTitleDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectTitle(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectTitles(string sdOid)
    {
        throw new NotImplementedException();
    }
}