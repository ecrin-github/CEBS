using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.RMS.DTO.v1;
using CEBS.Interfaces.RMS.Services;

namespace CEBS.Services.RMS;

public class DupService : IDupService
{
    public async Task<BaseResponse<DupDto>> GetAllDup()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupDto>> GetDup(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupDto>> GetRecentDup(int limit)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupDto>> CreateDup(DupDto dupDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupDto>> UpdateDup(DupDto dupDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDup(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupObjectDto>> GetDupObjects(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupObjectDto>> GetDupObject(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupObjectDto>> CreateDupObject(int dupId, DupObjectDto dupObjectDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupObjectDto>> UpdateDupObject(DupObjectDto dupObjectDto)
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

    public async Task<BaseResponse<DupPrereqDto>> GetDupPrereqs(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupPrereqDto>> GetDupPrereq(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupPrereqDto>> CreateDupPrereq(int dupId, DupPrereqDto dupPrereqDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupPrereqDto>> UpdateDupPrereq(DupPrereqDto dupPrereqDto)
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

    public async Task<BaseResponse<SecondaryUseDto>> GetSecondaryUses(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<SecondaryUseDto>> GetSecondaryUse(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<SecondaryUseDto>> CreateSecondaryUse(int dupId, SecondaryUseDto secondaryUseDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<SecondaryUseDto>> UpdateSecondaryUse(SecondaryUseDto secondaryUseDto)
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

    public async Task<BaseResponse<DuaDto>> GetAllDua(int dupId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DuaDto>> GetDua(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DuaDto>> CreateDua(int dupId, DuaDto duaDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DuaDto>> UpdateDua(DuaDto duaDto)
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

    public async Task<BaseResponse<DupDto>> PaginateDup(PaginationRequest paginationRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupDto>> FilterDupByTitle(FilteringByTitleRequest filteringByTitleRequest)
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