using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;

namespace CEBS.Services.RMS;

public class DtpService : IDtpService
{
    public async Task<BaseResponse<DtpDto>> GetAllDtp()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDto>> GetDtp(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDto>> GetRecentDtp(int limit)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDto>> CreateDtp(DtpDto dtpDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDto>> UpdateDtp(DtpDto dtpDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDtp(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtaDto>> GetAllDta(int dtpId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtaDto>> GetDta(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtaDto>> CreateDta(int dtpId, DtaDto dtaDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtaDto>> UpdateDta(DtaDto dtaDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDta(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllDta(int dtpId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDatasetDto>> GetAllDtpDatasets()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDatasetDto>> GetDtpDataset(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDatasetDto>> CreateDtpDataset(string objectId, DtpDatasetDto dtpDatasetDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDatasetDto>> UpdateDtpDataset(DtpDatasetDto dtpDatasetDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDtpDataset(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpObjectDto>> GetAllDtpObjects(int dtpId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpObjectDto>> GetDtpObject(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpObjectDto>> CreateDtpObject(int dtpId, string objectId, DtpObjectDto dtpObjectDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpObjectDto>> UpdateDtpObject(DtpObjectDto dtpObjectDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDtpObject(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllDtpObjects(int dtpId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpStudyDto>> GetAllDtpStudies(int dtpId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpStudyDto>> GetDtpStudy(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpStudyDto>> CreateDtpStudy(int dtpId, string studyId, DtpStudyDto dtpStudyDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpStudyDto>> UpdateDtpStudy(DtpStudyDto dtpStudyDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDtpStudy(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllDtpStudies(int dtpId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDto>> PaginateDtp(PaginationRequest paginationRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDto>> FilterDtpByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetTotalDtp()
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetUncompletedDtp()
    {
        throw new NotImplementedException();
    }
}