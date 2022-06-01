using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectDateService : IObjectDateService
{
    public async Task<BaseResponse<ObjectDateDto>> GetObjectDates(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDateDto>> GetObjectDate(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDateDto>> CreateObjectDate(ObjectDateDto objectDateDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDateDto>> UpdateObjectDate(ObjectDateDto objectDateDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectDate(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectDates(string sdOid)
    {
        throw new NotImplementedException();
    }
}