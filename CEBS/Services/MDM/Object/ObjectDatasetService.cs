using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectDatasetService : IObjectDatasetService
{
    public async Task<BaseResponse<ObjectDatasetDto>> GetObjectDatasets(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDatasetDto>> GetObjectDataset(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDatasetDto>> CreateObjectDataset(ObjectDatasetDto objectDatasetDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDatasetDto>> UpdateObjectDataset(ObjectDatasetDto objectDatasetDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectDataset(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectDatasets(string sdOid)
    {
        throw new NotImplementedException();
    }
}