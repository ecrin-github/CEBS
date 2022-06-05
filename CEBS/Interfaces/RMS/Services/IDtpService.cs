using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;

namespace CEBS.Interfaces.RMS.Services;

public interface IDtpService
{
    Task<BaseResponse<DtpDto>> GetAllDtp();
    Task<BaseResponse<DtpDto>> GetDtp(int id);
    Task<BaseResponse<DtpDto>> CreateDtp(DtpDto dtpDto);
    Task<BaseResponse<DtpDto>> UpdateDtp(DtpDto dtpDto);
    Task<int> DeleteDtp(int id);

    Task<BaseResponse<DtaDto>> GetAllDta(int dtpId);
    Task<BaseResponse<DtaDto>> GetDta(int id);
    Task<BaseResponse<DtaDto>> CreateDta(int dtpId, DtaDto dtaDto);
    Task<BaseResponse<DtaDto>> UpdateDta(DtaDto dtaDto);
    Task<int> DeleteDta(int id);
    Task<int> DeleteAllDta(int dtpId);

    Task<BaseResponse<DtpDatasetDto>> GetAllDtpDatasets();
    Task<BaseResponse<DtpDatasetDto>> GetDtpDataset(int id);
    Task<BaseResponse<DtpDatasetDto>> CreateDtpDataset(string objectId, DtpDatasetDto dtpDatasetDto);
    Task<BaseResponse<DtpDatasetDto>> UpdateDtpDataset(DtpDatasetDto dtpDatasetDto);
    Task<int> DeleteDtpDataset(int id);

    Task<BaseResponse<DtpObjectDto>> GetAllDtpObjects(int dtpId);
    Task<BaseResponse<DtpObjectDto>> GetDtpObject(int id);
    Task<BaseResponse<DtpObjectDto>> CreateDtpObject(int dtpId, string objectId, DtpObjectDto dtpObjectDto);
    Task<BaseResponse<DtpObjectDto>> UpdateDtpObject(DtpObjectDto dtpObjectDto);
    Task<int> DeleteDtpObject(int id);
    Task<int> DeleteAllDtpObjects(int dtpId);

    Task<BaseResponse<DtpStudyDto>> GetAllDtpStudies(int dtpId);
    Task<BaseResponse<DtpStudyDto>> GetDtpStudy(int id);
    Task<BaseResponse<DtpStudyDto>> CreateDtpStudy(int dtpId, string studyId, DtpStudyDto dtpStudyDto);
    Task<BaseResponse<DtpStudyDto>> UpdateDtpStudy(DtpStudyDto dtpStudyDto);
    Task<int> DeleteDtpStudy(int id);
    Task<int> DeleteAllDtpStudies(int dtpId);


    // Statistics
    Task<BaseResponse<DtpDto>> PaginateDtp(PaginationRequest paginationRequest);
    Task<BaseResponse<DtpDto>> FilterDtpByTitle(FilteringByTitleRequest filteringByTitleRequest);
    Task<int> GetTotalDtp();
    Task<int> GetUncompletedDtp();
}