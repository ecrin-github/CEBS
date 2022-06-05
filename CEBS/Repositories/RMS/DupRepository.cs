using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Interfaces.RMS.Repositories;
using CEBS.Models.DbContexts;
using CEBS.Models.RMS;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Repositories.RMS;

public class DupRepository : IDupRepository
{
    private readonly RmsDbContext _rmsDbContext;

    public DupRepository(RmsDbContext rmsDbContext)
    {
        _rmsDbContext = rmsDbContext ?? throw new ArgumentNullException(nameof(rmsDbContext));
    }
    
    public async Task<BaseResponse<Dup>> GetAllDup()
    {
        var data = await _rmsDbContext.Dups
            .AsNoTracking()
            .ToArrayAsync();
        return new BaseResponse<Dup>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<Dup>> GetDup(int id)
    {
        var data = await _rmsDbContext.Dups
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<Dup>
            {
                Total = 0,
                Data = Array.Empty<Dup>()
            };
        }

        return new BaseResponse<Dup>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<Dup>> CreateDup(Dup dup)
    {
        var res = await _rmsDbContext.Dups.AddAsync(dup);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDup(res.Entity.Id);
    }

    public async Task<BaseResponse<Dup>> UpdateDup(Dup dup)
    {
        var res = _rmsDbContext.Dups.Update(dup);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDup(res.Entity.Id);
    }

    public async Task<int> DeleteDup(int id)
    {
        var data = await GetDup(id);
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.Dups.RemoveRange(data.Data);
        await _rmsDbContext.SaveChangesAsync();
        
        return 1;
    }

    public async Task<BaseResponse<DupObject>> GetDupObjects(int dupId)
    {
        var data = await _rmsDbContext.DupObjects
            .AsNoTracking()
            .Where(p => p.DupId!.Equals(dupId))
            .ToArrayAsync();
        return new BaseResponse<DupObject>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<DupObject>> GetDupObject(int id)
    {
        var data = await _rmsDbContext.DupObjects
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<DupObject>
            {
                Total = 0,
                Data = Array.Empty<DupObject>()
            };
        }

        return new BaseResponse<DupObject>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<DupObject>> CreateDupObject(DupObject dupObject)
    {
        var res = await _rmsDbContext.DupObjects.AddAsync(dupObject);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDupObject(res.Entity.Id);
    }

    public async Task<BaseResponse<DupObject>> UpdateDupObject(DupObject dupObject)
    {
        var res = _rmsDbContext.DupObjects.Update(dupObject);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDupObject(res.Entity.Id);
    }

    public async Task<int> DeleteDupObject(int id)
    {
        var data = await GetDupObject(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.DupObjects.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return 1;
    }

    public async Task<int> DeleteAllDupObjects(int dupId)
    {
        var data = await GetDupObjects(dupId);
        
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.DupObjects.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<BaseResponse<DupPrereq>> GetDupPrereqs(int dupId)
    {
        var data = await _rmsDbContext.DupPrereqs
            .AsNoTracking()
            .Where(p => p.DupId!.Equals(dupId))
            .ToArrayAsync();
        return new BaseResponse<DupPrereq>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<DupPrereq>> GetDupPrereq(int id)
    {
        var data = await _rmsDbContext.DupPrereqs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<DupPrereq>
            {
                Total = 0,
                Data = Array.Empty<DupPrereq>()
            };
        }

        return new BaseResponse<DupPrereq>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<DupPrereq>> CreateDupPrereq(DupPrereq dupPrereq)
    {
        var res = await _rmsDbContext.DupPrereqs.AddAsync(dupPrereq);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDupPrereq(res.Entity.Id);
    }

    public async Task<BaseResponse<DupPrereq>> UpdateDupPrereq(DupPrereq dupPrereq)
    {
        var res = _rmsDbContext.DupPrereqs.Update(dupPrereq);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDupPrereq(res.Entity.Id);
    }

    public async Task<int> DeleteDupPrereq(int id)
    {
        var data = await GetDupPrereq(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.DupPrereqs.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return 1;
    }

    public async Task<int> DeleteAllDupPrereqs(int dupId)
    {
        var data = await GetDupPrereqs(dupId);
        
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.DupPrereqs.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<BaseResponse<SecondaryUse>> GetSecondaryUses(int dupId)
    {
        var data = await _rmsDbContext.SecondaryUses
            .AsNoTracking()
            .Where(p => p.DupId!.Equals(dupId))
            .ToArrayAsync();
        return new BaseResponse<SecondaryUse>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<SecondaryUse>> GetSecondaryUse(int id)
    {
        var data = await _rmsDbContext.SecondaryUses
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<SecondaryUse>
            {
                Total = 0,
                Data = Array.Empty<SecondaryUse>()
            };
        }

        return new BaseResponse<SecondaryUse>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<SecondaryUse>> CreateSecondaryUse(SecondaryUse secondaryUse)
    {
        var res = await _rmsDbContext.SecondaryUses.AddAsync(secondaryUse);
        await _rmsDbContext.SaveChangesAsync();

        return await GetSecondaryUse(res.Entity.Id);
    }

    public async Task<BaseResponse<SecondaryUse>> UpdateSecondaryUse(SecondaryUse secondaryUse)
    {
        var res = _rmsDbContext.SecondaryUses.Update(secondaryUse);
        await _rmsDbContext.SaveChangesAsync();

        return await GetSecondaryUse(res.Entity.Id);
    }

    public async Task<int> DeleteSecondaryUse(int id)
    {
        var data = await GetSecondaryUse(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.SecondaryUses.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return 1;
    }

    public async Task<int> DeleteAllSecondaryUses(int dupId)
    {
        var data = await GetSecondaryUses(dupId);
        
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.SecondaryUses.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<BaseResponse<Dua>> GetAllDua(int dupId)
    {
        var data = await _rmsDbContext.Duas
            .AsNoTracking()
            .Where(p => p.DupId!.Equals(dupId))
            .ToArrayAsync();
        return new BaseResponse<Dua>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<Dua>> GetDua(int id)
    {
        var data = await _rmsDbContext.Duas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<Dua>
            {
                Total = 0,
                Data = Array.Empty<Dua>()
            };
        }

        return new BaseResponse<Dua>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<Dua>> CreateDua(Dua dua)
    {
        var res = await _rmsDbContext.Duas.AddAsync(dua);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDua(res.Entity.Id);
    }

    public async Task<BaseResponse<Dua>> UpdateDua(Dua dua)
    {
        var res = _rmsDbContext.Duas.Update(dua);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDua(res.Entity.Id);
    }

    public async Task<int> DeleteDua(int id)
    {
        var data = await GetDua(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.Duas.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return 1;
    }

    public async Task<int> DeleteAllDua(int dupId)
    {
        var data = await GetAllDua(dupId);
        
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.Duas.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }
    
    private static int CalculateSkip(int page, int size)
    {
        var skip = 0;
        if (page > 1)
        {
            skip = (page - 1) * size;
        }

        return skip;
    }

    public async Task<BaseResponse<Dup>> PaginateDup(PaginationRequest paginationRequest)
    {
        var skip = CalculateSkip(paginationRequest.Page, paginationRequest.Size);
            
        var query = _rmsDbContext.Dups
            .AsNoTracking()
            .OrderBy(arg => arg.Id);
            
        var data = await query.Skip(skip).Take(paginationRequest.Size).ToArrayAsync();

        var total = await query.CountAsync();

        return new BaseResponse<Dup>
        {
            Total = total,
            Data = data
        };
    }

    public async Task<BaseResponse<Dup>> FilterDupByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        var skip = CalculateSkip(filteringByTitleRequest.Page, filteringByTitleRequest.Size);
            
        var query = _rmsDbContext.Dups
            .AsNoTracking()
            .Where(p => p.DisplayName!.ToLower().Contains(filteringByTitleRequest.Title.ToLower()))
            .OrderBy(arg => arg.Id);

        var data = await query
            .Skip(skip)
            .Take(filteringByTitleRequest.Size)
            .ToArrayAsync();

        var total = await query.CountAsync();

        return new BaseResponse<Dup>
        {
            Total = total,
            Data = data
        };
    }

    public async Task<int> GetTotalDup()
    {
        return await _rmsDbContext.Dups.AsNoTracking().CountAsync();
    }

    public async Task<int> GetUncompletedDup()
    {
        return await _rmsDbContext.Dups.AsNoTracking().Where(p => p.SetUpCompleted != null).CountAsync();
    }
}