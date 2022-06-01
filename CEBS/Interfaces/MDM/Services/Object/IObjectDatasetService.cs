using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectDatasetService
{
    // Object datasets
    Task<BaseResponse<ObjectDatasetDto>> GetObjectDatasets(string sdOid);
    Task<BaseResponse<ObjectDatasetDto>> GetObjectDataset(int id);
    Task<BaseResponse<ObjectDatasetDto>> CreateObjectDataset(ObjectDatasetDto objectDatasetDto);
    Task<BaseResponse<ObjectDatasetDto>> UpdateObjectDataset(ObjectDatasetDto objectDatasetDto);
    Task<int> DeleteObjectDataset(int id);
    Task<int> DeleteAllObjectDatasets(string sdOid);
}