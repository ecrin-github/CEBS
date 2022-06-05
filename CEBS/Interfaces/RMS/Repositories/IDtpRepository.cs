using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Models.RMS;

namespace CEBS.Interfaces.RMS.Repositories;

public interface IDtpRepository
{
    Task<BaseResponse<Dtp>> GetAllDtp();
    Task<BaseResponse<Dtp>> GetDtp(int id);
    Task<BaseResponse<Dtp>> CreateDtp(Dtp dtp);
    Task<BaseResponse<Dtp>> UpdateDtp(Dtp dtp);
    Task<int> DeleteDtp(int id);

    Task<BaseResponse<Dta>> GetAllDta(int dtpId);
    Task<BaseResponse<Dta>> GetDta(int id);
    Task<BaseResponse<Dta>> CreateDta(Dta dta);
    Task<BaseResponse<Dta>> UpdateDta(Dta dta);
    Task<int> DeleteDta(int id);
    Task<int> DeleteAllDta(int dtpId);

    Task<BaseResponse<DtpDataset>> GetAllDtpDatasets();
    Task<BaseResponse<DtpDataset>> GetDtpDataset(int id);
    Task<BaseResponse<DtpDataset>> CreateDtpDataset(DtpDataset dtpDataset);
    Task<BaseResponse<DtpDataset>> UpdateDtpDataset(DtpDataset dtpDataset);
    Task<int> DeleteDtpDataset(int id);

    Task<BaseResponse<DtpObject>> GetAllDtpObjects(int dtpId);
    Task<BaseResponse<DtpObject>> GetDtpObject(int id);
    Task<BaseResponse<DtpObject>> CreateDtpObject(DtpObject dtpObject);
    Task<BaseResponse<DtpObject>> UpdateDtpObject(DtpObject dtpObject);
    Task<int> DeleteDtpObject(int id);
    Task<int> DeleteAllDtpObjects(int dtpId);

    Task<BaseResponse<DtpStudy>> GetAllDtpStudies(int dtpId);
    Task<BaseResponse<DtpStudy>> GetDtpStudy(int id);
    Task<BaseResponse<DtpStudy>> CreateDtpStudy(DtpStudy dtpStudy);
    Task<BaseResponse<DtpStudy>> UpdateDtpStudy(DtpStudy dtpStudy);
    Task<int> DeleteDtpStudy(int id);
    Task<int> DeleteAllDtpStudies(int dtpId);


    Task<BaseResponse<Dtp>> PaginateDtp(PaginationRequest paginationRequest);
    Task<BaseResponse<Dtp>> FilterDtpByTitle(FilteringByTitleRequest filteringByTitleRequest);
    Task<int> GetTotalDtp();
    Task<int> GetUncompletedDtp();
}