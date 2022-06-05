using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Models.RMS;

namespace CEBS.Interfaces.RMS.Repositories;

public interface IDupRepository
{
    Task<BaseResponse<Dup>> GetAllDup();
    Task<BaseResponse<Dup>> GetDup(int id);
    Task<BaseResponse<Dup>> CreateDup(Dup dup);
    Task<BaseResponse<Dup>> UpdateDup(Dup dup);
    Task<int> DeleteDup(int id);

    Task<BaseResponse<DupObject>> GetDupObjects(int dupId);
    Task<BaseResponse<DupObject>> GetDupObject(int id);
    Task<BaseResponse<DupObject>> CreateDupObject(DupObject dupObject);
    Task<BaseResponse<DupObject>> UpdateDupObject(DupObject dupObject);
    Task<int> DeleteDupObject(int id);
    Task<int> DeleteAllDupObjects(int dupId);

    Task<BaseResponse<DupPrereq>> GetDupPrereqs(int dupId);
    Task<BaseResponse<DupPrereq>> GetDupPrereq(int id);
    Task<BaseResponse<DupPrereq>> CreateDupPrereq(DupPrereq dupPrereq);
    Task<BaseResponse<DupPrereq>> UpdateDupPrereq(DupPrereq dupPrereq);
    Task<int> DeleteDupPrereq(int id);
    Task<int> DeleteAllDupPrereqs(int dupId);

    Task<BaseResponse<SecondaryUse>> GetSecondaryUses(int dupId);
    Task<BaseResponse<SecondaryUse>> GetSecondaryUse(int id);
    Task<BaseResponse<SecondaryUse>> CreateSecondaryUse(SecondaryUse secondaryUse);
    Task<BaseResponse<SecondaryUse>> UpdateSecondaryUse(SecondaryUse secondaryUse);
    Task<int> DeleteSecondaryUse(int id);
    Task<int> DeleteAllSecondaryUses(int dupId);

    Task<BaseResponse<Dua>> GetAllDua(int dupId);
    Task<BaseResponse<Dua>> GetDua(int id);
    Task<BaseResponse<Dua>> CreateDua(Dua dua);
    Task<BaseResponse<Dua>> UpdateDua(Dua dua);
    Task<int> DeleteDua(int id);
    Task<int> DeleteAllDua(int dupId);


    Task<BaseResponse<Dup>> PaginateDup(PaginationRequest paginationRequest);
    Task<BaseResponse<Dup>> FilterDupByTitle(FilteringByTitleRequest filteringByTitleRequest);
    Task<int> GetTotalDup();
    Task<int> GetUncompletedDup();
}