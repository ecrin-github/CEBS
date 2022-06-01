using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Interfaces.RMS.Repositories;
using CEBS.Models.RMS;

namespace CEBS.Repositories.RMS;

public class DtpRepository : IDtpRepository
{
    public async Task<BaseResponse<Dtp>> GetAllDtp()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dtp>> GetDtp(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dtp>> GetRecentDtp(int limit)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dtp>> CreateDtp(Dtp dtp)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dtp>> UpdateDtp(Dtp dtp)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDtp(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dta>> GetAllDta(int dtpId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dta>> GetDta(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dta>> CreateDta(int dtpId, Dta dta)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dta>> UpdateDta(Dta dta)
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

    public async Task<BaseResponse<DtpDataset>> GetAllDtpDatasets()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDataset>> GetDtpDataset(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDataset>> CreateDtpDataset(string objectId, DtpDataset dtpDataset)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpDataset>> UpdateDtpDataset(DtpDataset dtpDataset)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDtpDataset(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpObject>> GetAllDtpObjects(int dtpId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpObject>> GetDtpObject(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpObject>> CreateDtpObject(int dtpId, string objectId, DtpObject dtpObject)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpObject>> UpdateDtpObject(DtpObject dtpObject)
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

    public async Task<BaseResponse<DtpStudy>> GetAllDtpStudies(int dtpId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpStudy>> GetDtpStudy(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpStudy>> CreateDtpStudy(int dtpId, string studyId, DtpStudy dtpStudy)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpStudy>> UpdateDtpStudy(DtpStudy dtpStudy)
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

    public async Task<BaseResponse<Dtp>> PaginateDtp(PaginationRequest paginationRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dtp>> FilterDtpByTitle(FilteringByTitleRequest filteringByTitleRequest)
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