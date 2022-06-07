using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Interfaces.MDM.Repositories;
using CEBS.Models.DbContexts;
using CEBS.Models.MDM.Study;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Repositories.MDM;

public class StudyRepository : IStudyRepository
{
    private readonly MdmDbContext _mdmDbContext;

    public StudyRepository(MdmDbContext mdmDbContext)
    {
        _mdmDbContext = mdmDbContext ?? throw new ArgumentNullException(nameof(mdmDbContext));
    }
    
    public async Task<BaseResponse<Study>> GetStudies()
    {
        var data = await _mdmDbContext.Studies
            .AsNoTracking()
            .ToArrayAsync();
        return new BaseResponse<Study>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<Study>> GetStudyById(int id)
    {
        var data = await _mdmDbContext.Studies
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<Study>
            {
                Total = 0,
                Data = Array.Empty<Study>()
            };
        }

        return new BaseResponse<Study>
        {
            Total = 1,
            Data = new [] { data }
        };
    }
    
    public async Task<BaseResponse<Study>> GetStudyBySdSid(string sdSid)
    {
        var data = await _mdmDbContext.Studies
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.SdSid!.ToUpper().Equals(sdSid.ToUpper()));

        if (data == null)
        {
            return new BaseResponse<Study>
            {
                Total = 0,
                Data = Array.Empty<Study>()
            };
        }

        return new BaseResponse<Study>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<Study>> CreateStudy(Study study)
    {
        var res = await _mdmDbContext.Studies.AddAsync(study);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyById(res.Entity.Id);
    }

    public async Task<BaseResponse<Study>> BulkCreateStudy(Study[] studies)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Study>> UpdateStudy(Study[] studies)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Study>> BulkUpdateStudy(Study[] study)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Study>> UpdateStudy(Study study)
    {
        var res = _mdmDbContext.Studies.Update(study);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyById(res.Entity.Id);
    }

    public async Task<int> DeleteStudy(string sdSid)
    {
        var study = await _mdmDbContext.Studies
            .FirstOrDefaultAsync(p => string.Equals(p.SdSid!, sdSid, StringComparison.CurrentCultureIgnoreCase));
        
        if (study == null) return 0;
        
        _mdmDbContext.Studies.Remove(study);
        
        await _mdmDbContext.SaveChangesAsync();
        
        return 1;
    }

    public async Task<BaseResponse<StudyContributor>> GetStudyContributors(string sdSid)
    {
        var data = await _mdmDbContext.StudyContributors
            .AsNoTracking()
            .Where(x => x.SdSid!.ToUpper().Equals(sdSid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<StudyContributor>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<StudyContributor>> GetStudyContributor(int id)
    {
        var data = await _mdmDbContext.StudyContributors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<StudyContributor>
            {
                Total = 0,
                Data = Array.Empty<StudyContributor>()
            };
        }

        return new BaseResponse<StudyContributor>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<StudyContributor>> CreateStudyContributor(StudyContributor studyContributor)
    {
        var res = await _mdmDbContext.StudyContributors.AddAsync(studyContributor);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyContributor(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyContributor>> UpdateStudyContributor(StudyContributor studyContributor)
    {
        var res = _mdmDbContext.StudyContributors.Update(studyContributor);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyContributor(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyContributor>> BulkCreateStudyContributor(StudyContributor[] studyContributors)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyContributor>> BulkUpdateStudyContributor(StudyContributor[] studyContributors)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyContributor(int id)
    {
        var data = await GetStudyContributor(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyContributors.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllStudyContributors(string sdSid)
    {
        var data = await GetStudyContributors(sdSid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyContributors.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<StudyFeature>> GetStudyFeatures(string sdSid)
    {
        var data = await _mdmDbContext.StudyFeatures
            .AsNoTracking()
            .Where(x => x.SdSid!.ToUpper().Equals(sdSid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<StudyFeature>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<StudyFeature>> GetStudyFeature(int id)
    {
        var data = await _mdmDbContext.StudyFeatures
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<StudyFeature>
            {
                Total = 0,
                Data = Array.Empty<StudyFeature>()
            };
        }

        return new BaseResponse<StudyFeature>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<StudyFeature>> CreateStudyFeature(StudyFeature studyFeature)
    {
        var res = await _mdmDbContext.StudyFeatures.AddAsync(studyFeature);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyFeature(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyFeature>> UpdateStudyFeature(StudyFeature studyFeature)
    {
        var res = _mdmDbContext.StudyFeatures.Update(studyFeature);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyFeature(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyFeature>> BulkCreateStudyFeature(StudyFeature[] studyFeatures)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyFeature>> BulkUpdateStudyFeature(StudyFeature[] studyFeatures)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyFeature(int id)
    {
        var data = await GetStudyFeature(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyFeatures.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllStudyFeatures(string sdSid)
    {
        var data = await GetStudyFeatures(sdSid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyFeatures.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<StudyIdentifier>> GetStudyIdentifiers(string sdSid)
    {
        var data = await _mdmDbContext.StudyIdentifiers
            .AsNoTracking()
            .Where(x => x.SdSid!.ToUpper().Equals(sdSid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<StudyIdentifier>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<StudyIdentifier>> GetStudyIdentifier(int id)
    {
        var data = await _mdmDbContext.StudyIdentifiers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<StudyIdentifier>
            {
                Total = 0,
                Data = Array.Empty<StudyIdentifier>()
            };
        }

        return new BaseResponse<StudyIdentifier>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<StudyIdentifier>> CreateStudyIdentifier(StudyIdentifier studyIdentifier)
    {
        var res = await _mdmDbContext.StudyIdentifiers.AddAsync(studyIdentifier);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyIdentifier(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyIdentifier>> UpdateStudyIdentifier(StudyIdentifier studyIdentifier)
    {
        var res = _mdmDbContext.StudyIdentifiers.Update(studyIdentifier);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyIdentifier(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyIdentifier>> BulkCreateStudyIdentifier(StudyIdentifier[] studyIdentifiers)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyIdentifier>> BulkUpdateStudyIdentifier(StudyIdentifier[] studyIdentifiers)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyIdentifier(int id)
    {
        var data = await GetStudyIdentifier(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyIdentifiers.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllStudyIdentifiers(string sdSid)
    {
        var data = await GetStudyIdentifiers(sdSid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyIdentifiers.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<StudyReference>> GetStudyReferences(string sdSid)
    {
        var data = await _mdmDbContext.StudyReferences
            .AsNoTracking()
            .Where(x => x.SdSid!.ToUpper().Equals(sdSid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<StudyReference>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<StudyReference>> GetStudyReference(int id)
    {
        var data = await _mdmDbContext.StudyReferences
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<StudyReference>
            {
                Total = 0,
                Data = Array.Empty<StudyReference>()
            };
        }

        return new BaseResponse<StudyReference>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<StudyReference>> CreateStudyReference(StudyReference studyReference)
    {
        var res = await _mdmDbContext.StudyReferences.AddAsync(studyReference);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyReference(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyReference>> UpdateStudyReference(StudyReference studyReference)
    {
        var res = _mdmDbContext.StudyReferences.Update(studyReference);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyReference(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyReference>> BulkCreateStudyReference(StudyReference[] studyReferences)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyReference>> BulkUpdateStudyReference(StudyReference[] studyReferences)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyReference(int id)
    {
        var data = await GetStudyReference(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyReferences.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllStudyReferences(string sdSid)
    {
        var data = await GetStudyReferences(sdSid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyReferences.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<StudyRelationship>> GetStudyRelationships(string sdSid)
    {
        var data = await _mdmDbContext.StudyRelationships
            .AsNoTracking()
            .Where(x => x.SdSid!.ToUpper().Equals(sdSid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<StudyRelationship>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<StudyRelationship>> GetStudyRelationship(int id)
    {
        var data = await _mdmDbContext.StudyRelationships
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<StudyRelationship>
            {
                Total = 0,
                Data = Array.Empty<StudyRelationship>()
            };
        }

        return new BaseResponse<StudyRelationship>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<StudyRelationship>> CreateStudyRelationship(StudyRelationship studyRelationship)
    {
        var res = await _mdmDbContext.StudyRelationships.AddAsync(studyRelationship);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyRelationship(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyRelationship>> UpdateStudyRelationship(StudyRelationship studyRelationship)
    {
        var res = _mdmDbContext.StudyRelationships.Update(studyRelationship);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyRelationship(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyRelationship>> BulkCreateStudyRelationship(StudyRelationship[] studyRelationships)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyRelationship>> BulkUpdateStudyRelationship(StudyRelationship[] studyRelationships)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyRelationship(int id)
    {
        var data = await GetStudyRelationship(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyRelationships.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllStudyRelationships(string sdSid)
    {
        var data = await GetStudyRelationships(sdSid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyRelationships.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<StudyTitle>> GetStudyTitles(string sdSid)
    {
        var data = await _mdmDbContext.StudyTitles
            .AsNoTracking()
            .Where(x => x.SdSid!.ToUpper().Equals(sdSid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<StudyTitle>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<StudyTitle>> GetStudyTitle(int id)
    {
        var data = await _mdmDbContext.StudyTitles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<StudyTitle>
            {
                Total = 0,
                Data = Array.Empty<StudyTitle>()
            };
        }

        return new BaseResponse<StudyTitle>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<StudyTitle>> CreateStudyTitle(StudyTitle studyTitle)
    {
        var res = await _mdmDbContext.StudyTitles.AddAsync(studyTitle);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyTitle(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyTitle>> UpdateStudyTitle(StudyTitle studyTitle)
    {
        var res = _mdmDbContext.StudyTitles.Update(studyTitle);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyTitle(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyTitle>> BulkCreateStudyTitle(StudyTitle[] studyTitles)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTitle>> BulkUpdateStudyTitle(StudyTitle[] studyTitles)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyTitle(int id)
    {
        var data = await GetStudyTitle(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyTitles.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllStudyTitles(string sdSid)
    {
        var data = await GetStudyTitles(sdSid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyTitles.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<StudyTopic>> GetStudyTopics(string sdSid)
    {
        var data = await _mdmDbContext.StudyTopics
            .AsNoTracking()
            .Where(x => x.SdSid!.ToUpper().Equals(sdSid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<StudyTopic>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<StudyTopic>> GetStudyTopic(int id)
    {
        var data = await _mdmDbContext.StudyTopics
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<StudyTopic>
            {
                Total = 0,
                Data = Array.Empty<StudyTopic>()
            };
        }

        return new BaseResponse<StudyTopic>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<StudyTopic>> CreateStudyTopic(StudyTopic studyTopic)
    {
        var res = await _mdmDbContext.StudyTopics.AddAsync(studyTopic);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyTopic(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyTopic>> UpdateStudyTopic(StudyTopic studyTopic)
    {
        var res = _mdmDbContext.StudyTopics.Update(studyTopic);
        await _mdmDbContext.SaveChangesAsync();

        return await GetStudyTopic(res.Entity.Id);
    }

    public async Task<BaseResponse<StudyTopic>> BulkCreateStudyTopic(StudyTopic[] studyTopics)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTopic>> BulkUpdateStudyTopic(StudyTopic[] studyTopics)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyTopic(int id)
    {
        var data = await GetStudyTopic(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyTopics.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllStudyTopics(string sdSid)
    {
        var data = await GetStudyTopics(sdSid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.StudyTopics.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
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

    public async Task<BaseResponse<Study>> PaginateStudies(PaginationRequest paginationRequest)
    {
        var skip = CalculateSkip(paginationRequest.Page, paginationRequest.Size);
            
        var query = _mdmDbContext.Studies
            .AsNoTracking()
            .OrderBy(arg => arg.Id);
            
        var data = await query.Skip(skip).Take(paginationRequest.Size).ToArrayAsync();

        var total = await query.CountAsync();

        return new BaseResponse<Study>
        {
            Total = total,
            Data = data
        };
    }

    public async Task<BaseResponse<Study>> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        var skip = CalculateSkip(filteringByTitleRequest.Page, filteringByTitleRequest.Size);
            
        var query = _mdmDbContext.Studies
            .AsNoTracking()
            .Where(p => p.DisplayTitle!.ToLower().Contains(filteringByTitleRequest.Title.ToLower()))
            .OrderBy(arg => arg.Id);

        var data = await query
            .Skip(skip)
            .Take(filteringByTitleRequest.Size)
            .ToArrayAsync();

        var total = await query.CountAsync();

        return new BaseResponse<Study>
        {
            Total = total,
            Data = data
        };
    }

    public async Task<int> GetTotalStudies()
    {
        return await _mdmDbContext.Studies.AsNoTracking().CountAsync();
    }
}