using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IDataObjectService
{
    // Data objects
    Task<BaseResponse<DataObjectDto>> GetAllDataObjects();
    Task<BaseResponse<DataObjectDto>> GetObjectBySdOid(string sdOid);
    Task<BaseResponse<DataObjectDto>> GetObjectById(int id);
    Task<BaseResponse<DataObjectDto>> CreateDataObject(DataObjectDto dataObjectDto);
    Task<BaseResponse<DataObjectDto>> UpdateDataObject(DataObjectDto dataObjectDto);
    Task<int> DeleteDataObject(string sdOid);
    
    // Extensions
    Task<BaseResponse<DataObjectDto>> PaginateDataObjects(PaginationRequest paginationRequest);
    Task<BaseResponse<DataObjectDto>> FilterDataObjectsByTitle(FilteringByTitleRequest filteringByTitleRequest);
    Task<int> GetTotalDataObjects();
}