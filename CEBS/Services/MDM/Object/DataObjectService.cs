using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.Mapping;
using CEBS.Interfaces.MDM.Repositories;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class DataObjectService : IDataObjectService
{
    private readonly IObjectRepository _objectRepository;
    private readonly IMdmMapping _mdmMapping;

    public DataObjectService(IObjectRepository objectRepository, IMdmMapping mdmMapping)
    {
        _objectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
        _mdmMapping = mdmMapping ?? throw new ArgumentNullException(nameof(mdmMapping));
    }
    
    public async Task<BaseResponse<DataObjectDto>> GetDataObjects()
    {
        var data = await _objectRepository.GetDataObjects();
        return new BaseResponse<DataObjectDto>
        {
            Total = data.Total,
            Data = _mdmMapping.DataObjectDtoBuilder(data.Data)
        };
    }

    public async Task<BaseResponse<DataObjectDto>> GetObjectBySdOid(string sdOid)
    {
        var data = await _objectRepository.GetObjectBySdOid(sdOid);
        return new BaseResponse<DataObjectDto>
        {
            Total = data.Total,
            Data = _mdmMapping.DataObjectDtoBuilder(data.Data)
        };
    }

    public async Task<BaseResponse<DataObjectDto>> GetObjectById(int id)
    {
        var data = await _objectRepository.GetObjectById(id);
        return new BaseResponse<DataObjectDto>
        {
            Total = data.Total,
            Data = _mdmMapping.DataObjectDtoBuilder(data.Data)
        };
    }

    public async Task<BaseResponse<DataObjectDto>> CreateDataObject(DataObjectDto dataObjectDto)
    {
        
        
        var data = await _objectRepository.CreateDataObject();
        return new BaseResponse<DataObjectDto>
        {
            Total = data.Total,
            Data = _mdmMapping.DataObjectDtoBuilder(data.Data)
        };
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