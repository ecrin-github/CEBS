using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;

namespace CEBS.Interfaces.RMS.Services;

public interface IDupService
{
    Task<BaseResponse<DupDto>> GetAllDup();
    Task<BaseResponse<DupDto>> GetDup(int id);
    Task<BaseResponse<DupDto>> GetRecentDup(int limit);
    Task<BaseResponse<DupDto>> CreateDup(DupDto dupDto);
    Task<BaseResponse<DupDto>> UpdateDup(DupDto dupDto);
    Task<int> DeleteDup(int id);

    Task<BaseResponse<DupObjectDto>> GetDupObjects(int dupId);
    Task<BaseResponse<DupObjectDto>> GetDupObject(int id);
    Task<BaseResponse<DupObjectDto>> CreateDupObject(int dupId, DupObjectDto dupObjectDto);
    Task<BaseResponse<DupObjectDto>> UpdateDupObject(DupObjectDto dupObjectDto);
    Task<int> DeleteDupObject(int id);
    Task<int> DeleteAllDupObjects(int dupId);

    Task<BaseResponse<DupPrereqDto>> GetDupPrereqs(int dupId);
    Task<BaseResponse<DupPrereqDto>> GetDupPrereq(int id);
    Task<BaseResponse<DupPrereqDto>> CreateDupPrereq(int dupId, DupPrereqDto dupPrereqDto);
    Task<BaseResponse<DupPrereqDto>> UpdateDupPrereq(DupPrereqDto dupPrereqDto);
    Task<int> DeleteDupPrereq(int id);
    Task<int> DeleteAllDupPrereqs(int dupId);

    Task<BaseResponse<SecondaryUseDto>> GetSecondaryUses(int dupId);
    Task<BaseResponse<SecondaryUseDto>> GetSecondaryUse(int id);
    Task<BaseResponse<SecondaryUseDto>> CreateSecondaryUse(int dupId, SecondaryUseDto secondaryUseDto);
    Task<BaseResponse<SecondaryUseDto>> UpdateSecondaryUse(SecondaryUseDto secondaryUseDto);
    Task<int> DeleteSecondaryUse(int id);
    Task<int> DeleteAllSecondaryUses(int dupId);

    Task<BaseResponse<DuaDto>> GetAllDua(int dupId);
    Task<BaseResponse<DuaDto>> GetDua(int id);
    Task<BaseResponse<DuaDto>> CreateDua(int dupId, DuaDto duaDto);
    Task<BaseResponse<DuaDto>> UpdateDua(DuaDto duaDto);
    Task<int> DeleteDua(int id);
    Task<int> DeleteAllDua(int dupId);


    // Statistics
    Task<BaseResponse<DupDto>> PaginateDup(PaginationRequest paginationRequest);
    Task<BaseResponse<DupDto>> FilterDupByTitle(FilteringByTitleRequest filteringByTitleRequest);
    Task<int> GetTotalDup();
    Task<int> GetUncompletedDup();
}