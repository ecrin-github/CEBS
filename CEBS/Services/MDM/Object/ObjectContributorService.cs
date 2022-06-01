using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectContributorService : IObjectContributorService
{
    public async Task<BaseResponse<ObjectContributorDto>> GetObjectContributors(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectContributorDto>> GetObjectContributor(int? id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectContributorDto>> CreateObjectContributor(ObjectContributorDto objectContributorDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectContributorDto>> UpdateObjectContributor(ObjectContributorDto objectContributorDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectContributor(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectContributors(string sdOid)
    {
        throw new NotImplementedException();
    }
}