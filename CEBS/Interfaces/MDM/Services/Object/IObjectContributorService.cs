using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectContributorService
{
    Task<BaseResponse<ObjectContributorDto>> GetObjectContributors(string sdOid);
    Task<BaseResponse<ObjectContributorDto>> GetObjectContributor(int? id);
    Task<BaseResponse<ObjectContributorDto>> CreateObjectContributor(ObjectContributorDto objectContributorDto);
    Task<BaseResponse<ObjectContributorDto>> UpdateObjectContributor(ObjectContributorDto objectContributorDto);
    Task<int> DeleteObjectContributor(int id);
    Task<int> DeleteAllObjectContributors(string sdOid);
}