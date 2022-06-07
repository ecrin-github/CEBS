using CEBS.Contracts.Requests.RMS.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Interfaces.RMS.Repositories;
using CEBS.Models.DbContexts;
using CEBS.Models.RMS;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Repositories.RMS;

public class DtpRepository : IDtpRepository
{
    private readonly RmsDbContext _rmsDbContext;

    public DtpRepository(RmsDbContext rmsDbContext)
    {
        _rmsDbContext = rmsDbContext ?? throw new ArgumentNullException(nameof(rmsDbContext));
    }
    
    public async Task<BaseResponse<Dtp>> GetAllDtp()
    {
        var data = await _rmsDbContext.Dtps
            .AsNoTracking()
            .ToArrayAsync();
        return new BaseResponse<Dtp>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<Dtp>> GetDtp(int id)
    {
        var data = await _rmsDbContext.Dtps
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<Dtp>
            {
                Total = 0,
                Data = Array.Empty<Dtp>()
            };
        }

        return new BaseResponse<Dtp>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<Dtp>> CreateDtp(Dtp dtp)
    {
        var res = await _rmsDbContext.Dtps.AddAsync(dtp);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDtp(res.Entity.Id);
    }

    public async Task<BaseResponse<Dtp>> UpdateDtp(Dtp dtp)
    {
        var res = _rmsDbContext.Dtps.Update(dtp);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDtp(res.Entity.Id);
    }

    public async Task<int> DeleteDtp(int id)
    {
        var data = await GetDtp(id);
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _rmsDbContext.Dtps.RemoveRange(data.Data);
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<BaseResponse<Dta>> GetAllDta(int dtpId)
    {
        var data = await _rmsDbContext.Dtas
            .AsNoTracking()
            .Where(p => p.DtpId!.Equals(dtpId))
            .ToArrayAsync();
        return new BaseResponse<Dta>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<Dta>> GetDta(int id)
    {
        var data = await _rmsDbContext.Dtas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<Dta>
            {
                Total = 0,
                Data = Array.Empty<Dta>()
            };
        }

        return new BaseResponse<Dta>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<Dta>> CreateDta(Dta dta)
    {
        var res = await _rmsDbContext.Dtas.AddAsync(dta);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDta(res.Entity.Id);
    }

    public async Task<BaseResponse<Dta>> UpdateDta(Dta dta)
    {
        var res = _rmsDbContext.Dtas.Update(dta);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDta(res.Entity.Id);
    }

    public async Task<int> DeleteDta(int id)
    {
        var data = await GetDta(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _rmsDbContext.Dtas.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllDta(int dtpId)
    {
        var data = await GetAllDta(dtpId);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _rmsDbContext.Dtas.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<BaseResponse<DtpDataset>> GetAllDtpDatasets()
    {
        var data = await _rmsDbContext.DtpDatasets
            .AsNoTracking()
            .ToArrayAsync();
        return new BaseResponse<DtpDataset>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<DtpDataset>> GetDtpDataset(int id)
    {
        var data = await _rmsDbContext.DtpDatasets
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<DtpDataset>
            {
                Total = 0,
                Data = Array.Empty<DtpDataset>()
            };
        }

        return new BaseResponse<DtpDataset>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<DtpDataset>> CreateDtpDataset(DtpDataset dtpDataset)
    {
        var res = await _rmsDbContext.DtpDatasets.AddAsync(dtpDataset);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDtpDataset(res.Entity.Id);
    }

    public async Task<BaseResponse<DtpDataset>> UpdateDtpDataset(DtpDataset dtpDataset)
    {
        var res = _rmsDbContext.DtpDatasets.Update(dtpDataset);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDtpDataset(res.Entity.Id);
    }

    public async Task<int> DeleteDtpDataset(int id)
    {
        var data = await GetDtpDataset(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _rmsDbContext.DtpDatasets.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<BaseResponse<DtpObject>> GetAllDtpObjects(int dtpId)
    {
        var data = await _rmsDbContext.DtpObjects
            .AsNoTracking()
            .Where(p => p.DtpId!.Equals(dtpId))
            .ToArrayAsync();
        return new BaseResponse<DtpObject>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<DtpObject>> GetDtpObject(int id)
    {
        var data = await _rmsDbContext.DtpObjects
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<DtpObject>
            {
                Total = 0,
                Data = Array.Empty<DtpObject>()
            };
        }

        return new BaseResponse<DtpObject>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<DtpObject>> CreateDtpObject(DtpObject dtpObject)
    {
        var res = await _rmsDbContext.DtpObjects.AddAsync(dtpObject);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDtpObject(res.Entity.Id);
    }

    public async Task<BaseResponse<DtpObject>> UpdateDtpObject(DtpObject dtpObject)
    {
        var res = _rmsDbContext.DtpObjects.Update(dtpObject);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDtpObject(res.Entity.Id);
    }

    public async Task<int> DeleteDtpObject(int id)
    {
        var data = await GetDtpObject(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _rmsDbContext.DtpObjects.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllDtpObjects(int dtpId)
    {
        var data = await GetAllDtpObjects(dtpId);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _rmsDbContext.DtpObjects.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<BaseResponse<DtpStudy>> GetAllDtpStudies(int dtpId)
    {
        var data = await _rmsDbContext.DtpStudies
            .AsNoTracking()
            .Where(p => p.DtpId!.Equals(dtpId))
            .ToArrayAsync();
        return new BaseResponse<DtpStudy>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<DtpStudy>> GetDtpStudy(int id)
    {
        var data = await _rmsDbContext.DtpStudies
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<DtpStudy>
            {
                Total = 0,
                Data = Array.Empty<DtpStudy>()
            };
        }

        return new BaseResponse<DtpStudy>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<DtpStudy>> CreateDtpStudy(DtpStudy dtpStudy)
    {
        var res = await _rmsDbContext.DtpStudies.AddAsync(dtpStudy);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDtpStudy(res.Entity.Id);
    }

    public async Task<BaseResponse<DtpStudy>> UpdateDtpStudy(DtpStudy dtpStudy)
    {
        var res = _rmsDbContext.DtpStudies.Update(dtpStudy);
        await _rmsDbContext.SaveChangesAsync();

        return await GetDtpStudy(res.Entity.Id);
    }

    public async Task<int> DeleteDtpStudy(int id)
    {
        var data = await GetDtpStudy(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _rmsDbContext.DtpStudies.RemoveRange(data.Data);
        
        await _rmsDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllDtpStudies(int dtpId)
    {
        var data = await GetAllDtpStudies(dtpId);
        
        if (data.Total == 0 && data.Data.Length == 0) return 0;
        
        _rmsDbContext.DtpStudies.RemoveRange(data.Data);
        
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

    public async Task<BaseResponse<Dtp>> PaginateDtp(PaginationRequest paginationRequest)
    {
        var skip = CalculateSkip(paginationRequest.Page, paginationRequest.Size);
            
        var query = _rmsDbContext.Dtps
            .AsNoTracking()
            .OrderBy(arg => arg.Id);
            
        var data = await query.Skip(skip).Take(paginationRequest.Size).ToArrayAsync();

        var total = await query.CountAsync();

        return new BaseResponse<Dtp>
        {
            Total = total,
            Data = data
        };
    }

    public async Task<BaseResponse<Dtp>> FilterDtpByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        var skip = CalculateSkip(filteringByTitleRequest.Page, filteringByTitleRequest.Size);
            
        var query = _rmsDbContext.Dtps
            .AsNoTracking()
            .Where(p => p.DisplayName!.ToLower().Contains(filteringByTitleRequest.Title.ToLower()))
            .OrderBy(arg => arg.Id);

        var data = await query
            .Skip(skip)
            .Take(filteringByTitleRequest.Size)
            .ToArrayAsync();

        var total = await query.CountAsync();

        return new BaseResponse<Dtp>
        {
            Total = total,
            Data = data
        };
    }

    public async Task<int> GetTotalDtp()
    {
        return await _rmsDbContext.Dtps.AsNoTracking().CountAsync();
    }

    public async Task<int> GetUncompletedDtp()
    {
        return await _rmsDbContext.Dtps.AsNoTracking().Where(p => p.SetUpCompleted != null).CountAsync();
    }
}