using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Interfaces.RMS.Repositories;
using CEBS.Models.RMS;

namespace CEBS.Repositories.RMS;

public class DupRepository : IDupRepository
{
    public async Task<BaseResponse<Dup>> GetAllDup()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dup>> GetDup(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dup>> GetRecentDup(int limit)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dup>> CreateDup(Dup dup)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dup>> UpdateDup(Dup dup)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDup(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupObject>> GetDupObjects(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupObject>> GetDupObject(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupObject>> CreateDupObject(int dupId, DupObject dupObject)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupObject>> UpdateDupObject(DupObject dupObject)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDupObject(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllDupObjects(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupPrereq>> GetDupPrereqs(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupPrereq>> GetDupPrereq(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupPrereq>> CreateDupPrereq(int dupId, DupPrereq dupPrereq)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupPrereq>> UpdateDupPrereq(DupPrereq dupPrereq)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDupPrereq(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllDupPrereqs(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<SecondaryUse>> GetSecondaryUses(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<SecondaryUse>> GetSecondaryUse(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<SecondaryUse>> CreateSecondaryUse(int dupId, SecondaryUse secondaryUse)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<SecondaryUse>> UpdateSecondaryUse(SecondaryUse secondaryUse)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteSecondaryUse(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllSecondaryUses(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dua>> GetAllDua(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dua>> GetDua(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dua>> CreateDua(int dupId, Dua dua)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dua>> UpdateDua(Dua dua)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDua(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllDua(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dup>> PaginateDup(PaginationRequest paginationRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Dup>> FilterDupByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetTotalDup()
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetUncompletedDup()
    {
        throw new NotImplementedException();
    }
}