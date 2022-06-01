using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class DataObjectService : IDataObjectService
{
    public async Task<BaseResponse<DataObjectDto>> GetAllDataObjects()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DataObjectDto>> GetObjectBySdOid(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DataObjectDto>> GetObjectById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DataObjectDto>> CreateDataObject(DataObjectDto dataObjectDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DataObjectDto>> UpdateDataObject(DataObjectDto dataObjectDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDataObject(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DataObjectDto>> PaginateDataObjects(PaginationRequest paginationRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DataObjectDto>> FilterDataObjectsByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetTotalDataObjects()
    {
        throw new NotImplementedException();
    }
}