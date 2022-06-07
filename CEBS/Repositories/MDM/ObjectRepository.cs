using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Interfaces.MDM.Repositories;
using CEBS.Models.DbContexts;
using CEBS.Models.MDM.Object;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Repositories.MDM;

public class ObjectRepository : IObjectRepository
{
    private readonly MdmDbContext _mdmDbContext;

    public ObjectRepository(MdmDbContext mdmDbContext)
    {
        _mdmDbContext = mdmDbContext ?? throw new ArgumentNullException(nameof(mdmDbContext));
    }
    
    public async Task<BaseResponse<DataObject>> GetDataObjects()
    {
        var data = await _mdmDbContext.DataObjects
            .AsNoTracking()
            .ToArrayAsync();
        return new BaseResponse<DataObject>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<DataObject>> GetObjectBySdOid(string sdOid)
    {
        var data = await _mdmDbContext.DataObjects
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()));

        if (data == null)
        {
            return new BaseResponse<DataObject>
            {
                Total = 0,
                Data = Array.Empty<DataObject>()
            };
        }

        return new BaseResponse<DataObject>
        {
            Total = 1,
            Data = new [] { data }
        };
    }
    
    public async Task<BaseResponse<DataObject>> GetObjectById(int id)
    {
        var data = await _mdmDbContext.DataObjects
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<DataObject>
            {
                Total = 0,
                Data = Array.Empty<DataObject>()
            };
        }

        return new BaseResponse<DataObject>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<DataObject>> CreateDataObject(DataObject dataObject)
    {
        var res = await _mdmDbContext.DataObjects.AddAsync(dataObject);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectById(res.Entity.Id);
    }

    public async Task<BaseResponse<DataObject>> UpdateDataObject(DataObject dataObject)
    {
        var res = _mdmDbContext.DataObjects.Update(dataObject);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectById(res.Entity.Id);
    }

    public async Task<BaseResponse<DataObject>> BulkCreateDataObject(DataObject[] dataObjects)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DataObject>> BulkUpdateDataObject(DataObject[] dataObjects)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteDataObject(string sdOid)
    {
        var dataObject = await _mdmDbContext.DataObjects
            .FirstOrDefaultAsync(p => string.Equals(p.SdOid!, sdOid, StringComparison.CurrentCultureIgnoreCase));
        
        if (dataObject == null) return 0;
        
        _mdmDbContext.DataObjects.Remove(dataObject);
        
        await _mdmDbContext.SaveChangesAsync();
        
        return 1;
    }

    public async Task<BaseResponse<ObjectContributor>> GetObjectContributors(string sdOid)
    {
        var data = await _mdmDbContext.ObjectContributors
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        
        return new BaseResponse<ObjectContributor>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectContributor>> GetObjectContributor(int id)
    {
        var data = await _mdmDbContext.ObjectContributors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<ObjectContributor>
            {
                Total = 0,
                Data = Array.Empty<ObjectContributor>()
            };
        }

        return new BaseResponse<ObjectContributor>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectContributor>> CreateObjectContributor(ObjectContributor objectContributor)
    {
        var res = await _mdmDbContext.ObjectContributors.AddAsync(objectContributor);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectContributor(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectContributor>> UpdateObjectContributor(ObjectContributor objectContributor)
    {
        var res = _mdmDbContext.ObjectContributors.Update(objectContributor);
        
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectContributor(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectContributor>> BulkCreateObjectContributor(ObjectContributor[] objectContributors)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectContributor>> BulkUpdateObjectContributor(ObjectContributor[] objectContributors)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectContributor(int id)
    {
        var data = await GetObjectContributor(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectContributors.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectContributors(string sdOid)
    {
        var data = await GetObjectContributors(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectContributors.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<ObjectDataset>> GetObjectDatasets(string sdOid)
    {
        var data = await _mdmDbContext.ObjectDatasets
            .AsNoTracking()
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<ObjectDataset>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectDataset>> GetObjectDataset(int id)
    {
        var data = await _mdmDbContext.ObjectDatasets
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<ObjectDataset>
            {
                Total = 0,
                Data = Array.Empty<ObjectDataset>()
            };
        }

        return new BaseResponse<ObjectDataset>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectDataset>> CreateObjectDataset(ObjectDataset objectDataset)
    {
        var res = await _mdmDbContext.ObjectDatasets.AddAsync(objectDataset);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectDataset(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectDataset>> UpdateObjectDataset(ObjectDataset objectDataset)
    {
        var res = _mdmDbContext.ObjectDatasets.Update(objectDataset);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectDataset(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectDataset>> BulkCreateObjectDataset(ObjectDataset[] objectDatasets)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDataset>> BulkUpdateObjectDataset(ObjectDataset[] objectDatasets)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectDataset(int id)
    {
        var data = await GetObjectDataset(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectDatasets.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectDatasets(string sdOid)
    {
        var data = await GetObjectDatasets(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectDatasets.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<ObjectDate>> GetObjectDates(string sdOid)
    {
        var data = await _mdmDbContext.ObjectDates
            .AsNoTracking()
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<ObjectDate>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectDate>> GetObjectDate(int id)
    {
        var data = await _mdmDbContext.ObjectDates
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<ObjectDate>
            {
                Total = 0,
                Data = Array.Empty<ObjectDate>()
            };
        }

        return new BaseResponse<ObjectDate>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectDate>> CreateObjectDate(ObjectDate objectDate)
    {
        var res = await _mdmDbContext.ObjectDates.AddAsync(objectDate);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectDate(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectDate>> UpdateObjectDate(ObjectDate objectDate)
    {
        var res = _mdmDbContext.ObjectDates.Update(objectDate);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectDate(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectDate>> BulkCreateObjectDate(ObjectDate[] objectDates)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDate>> BulkUpdateObjectDate(ObjectDate[] objectDates)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectDate(int id)
    {
        var data = await GetObjectDate(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectDates.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectDates(string sdOid)
    {
        var data = await GetObjectDates(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectDates.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<ObjectDescription>> GetObjectDescriptions(string sdOid)
    {
        var data = await _mdmDbContext.ObjectDescriptions
            .AsNoTracking()
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<ObjectDescription>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectDescription>> GetObjectDescription(int id)
    {
        var data = await _mdmDbContext.ObjectDescriptions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<ObjectDescription>
            {
                Total = 0,
                Data = Array.Empty<ObjectDescription>()
            };
        }

        return new BaseResponse<ObjectDescription>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectDescription>> CreateObjectDescription(ObjectDescription objectDescription)
    {
        var res = await _mdmDbContext.ObjectDescriptions.AddAsync(objectDescription);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectDescription(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectDescription>> UpdateObjectDescription(ObjectDescription objectDescription)
    {
        var res = _mdmDbContext.ObjectDescriptions.Update(objectDescription);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectDescription(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectDescription>> BulkCreateObjectDescription(ObjectDescription[] objectDescriptions)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectDescription>> BulkUpdateObjectDescription(ObjectDescription[] objectDescriptions)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectDescription(int id)
    {
        var data = await GetObjectDescription(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectDescriptions.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectDescriptions(string sdOid)
    {
        var data = await GetObjectDescriptions(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectDescriptions.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<ObjectIdentifier>> GetObjectIdentifiers(string sdOid)
    {
        var data = await _mdmDbContext.ObjectIdentifiers
            .AsNoTracking()
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<ObjectIdentifier>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectIdentifier>> GetObjectIdentifier(int id)
    {
        var data = await _mdmDbContext.ObjectIdentifiers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<ObjectIdentifier>
            {
                Total = 0,
                Data = Array.Empty<ObjectIdentifier>()
            };
        }

        return new BaseResponse<ObjectIdentifier>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectIdentifier>> CreateObjectIdentifier(ObjectIdentifier objectIdentifier)
    {
        var res = await _mdmDbContext.ObjectIdentifiers.AddAsync(objectIdentifier);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectIdentifier(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectIdentifier>> UpdateObjectIdentifier(ObjectIdentifier objectIdentifier)
    {
        var res = _mdmDbContext.ObjectIdentifiers.Update(objectIdentifier);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectIdentifier(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectIdentifier>> BulkCreateObjectIdentifier(ObjectIdentifier[] objectIdentifiers)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectIdentifier>> BulkUpdateObjectIdentifier(ObjectIdentifier[] objectIdentifiers)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectIdentifier(int id)
    {
        var data = await GetObjectIdentifier(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectIdentifiers.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectIdentifiers(string sdOid)
    {
        var data = await GetObjectIdentifiers(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectIdentifiers.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<ObjectInstance>> GetObjectInstances(string sdOid)
    {
        var data = await _mdmDbContext.ObjectInstances
            .AsNoTracking()
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<ObjectInstance>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectInstance>> GetObjectInstance(int id)
    {
        var data = await _mdmDbContext.ObjectInstances
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
        
        if (data == null)
        {
            return new BaseResponse<ObjectInstance>
            {
                Total = 0,
                Data = Array.Empty<ObjectInstance>()
            };
        }

        return new BaseResponse<ObjectInstance>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectInstance>> CreateObjectInstance(ObjectInstance objectInstance)
    {
        var res = await _mdmDbContext.ObjectInstances.AddAsync(objectInstance);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectInstance(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectInstance>> UpdateObjectInstance(ObjectInstance objectInstance)
    {
        var res = _mdmDbContext.ObjectInstances.Update(objectInstance);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectInstance(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectInstance>> BulkCreateObjectInstance(ObjectInstance[] objectInstances)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectInstance>> BulkUpdateObjectInstance(ObjectInstance[] objectInstances)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectInstance(int id)
    {
        var data = await GetObjectInstance(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectInstances.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectInstances(string sdOid)
    {
        var data = await GetObjectInstances(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectInstances.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<ObjectRelationship>> GetObjectRelationships(string sdOid)
    {
        var data = await _mdmDbContext.ObjectRelationships
            .AsNoTracking()
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<ObjectRelationship>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectRelationship>> GetObjectRelationship(int id)
    {
        var data = await _mdmDbContext.ObjectRelationships
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<ObjectRelationship>
            {
                Total = 0,
                Data = Array.Empty<ObjectRelationship>()
            };
        }

        return new BaseResponse<ObjectRelationship>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectRelationship>> CreateObjectRelationship(ObjectRelationship objectRelationship)
    {
        var res = await _mdmDbContext.ObjectRelationships.AddAsync(objectRelationship);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectRelationship(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectRelationship>> UpdateObjectRelationship(ObjectRelationship objectRelationship)
    {
        var res = _mdmDbContext.ObjectRelationships.Update(objectRelationship);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectRelationship(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectRelationship>> BulkCreateObjectRelationship(ObjectRelationship[] objectRelationships)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectRelationship>> BulkUpdateObjectRelationship(ObjectRelationship[] objectRelationships)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectRelationship(int id)
    {
        var data = await GetObjectRelationship(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectRelationships.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectRelationships(string sdOid)
    {
        var data = await GetObjectRelationships(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectRelationships.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<ObjectRight>> GetObjectRights(string sdOid)
    {
        var data = await _mdmDbContext.ObjectRights
            .AsNoTracking()
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<ObjectRight>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectRight>> GetObjectRight(int id)
    {
        var data = await _mdmDbContext.ObjectRights
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<ObjectRight>
            {
                Total = 0,
                Data = Array.Empty<ObjectRight>()
            };
        }

        return new BaseResponse<ObjectRight>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectRight>> CreateObjectRight(ObjectRight objectRight)
    {
        var res = await _mdmDbContext.ObjectRights.AddAsync(objectRight);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectRight(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectRight>> UpdateObjectRight(ObjectRight objectRight)
    {
        var res = _mdmDbContext.ObjectRights.Update(objectRight);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectRight(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectRight>> BulkCreateObjectRight(ObjectRight[] objectRights)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectRight>> BulkUpdateObjectRight(ObjectRight[] objectRights)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectRight(int id)
    {
        var data = await GetObjectRight(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectRights.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectRights(string sdOid)
    {
        var data = await GetObjectRights(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectRights.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<ObjectTitle>> GetObjectTitles(string sdOid)
    {
        var data = await _mdmDbContext.ObjectTitles
            .AsNoTracking()
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<ObjectTitle>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectTitle>> GetObjectTitle(int id)
    {
        var data = await _mdmDbContext.ObjectTitles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<ObjectTitle>
            {
                Total = 0,
                Data = Array.Empty<ObjectTitle>()
            };
        }

        return new BaseResponse<ObjectTitle>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectTitle>> CreateObjectTitle(ObjectTitle objectTitle)
    {
        var res = await _mdmDbContext.ObjectTitles.AddAsync(objectTitle);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectTitle(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectTitle>> UpdateObjectTitle(ObjectTitle objectTitle)
    {
        var res = _mdmDbContext.ObjectTitles.Update(objectTitle);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectTitle(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectTitle>> BulkCreateObjectTitle(ObjectTitle[] objectTitles)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectTitle>> BulkUpdateObjectTitle(ObjectTitle[] objectTitles)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectTitle(int id)
    {
        var data = await GetObjectTitle(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectTitles.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectTitles(string sdOid)
    {
        var data = await GetObjectTitles(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectTitles.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        return data.Total;
    }

    public async Task<BaseResponse<ObjectTopic>> GetObjectTopics(string sdOid)
    {
        var data = await _mdmDbContext.ObjectTopics
            .AsNoTracking()
            .Where(x => x.SdOid!.ToUpper().Equals(sdOid.ToUpper()))
            .ToArrayAsync();
        return new BaseResponse<ObjectTopic>
        {
            Total = data.Length,
            Data = data
        };
    }

    public async Task<BaseResponse<ObjectTopic>> GetObjectTopic(int id)
    {
        var data = await _mdmDbContext.ObjectTopics
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (data == null)
        {
            return new BaseResponse<ObjectTopic>
            {
                Total = 0,
                Data = Array.Empty<ObjectTopic>()
            };
        }

        return new BaseResponse<ObjectTopic>
        {
            Total = 1,
            Data = new [] { data }
        };
    }

    public async Task<BaseResponse<ObjectTopic>> CreateObjectTopic(ObjectTopic objectTopic)
    {
        var res = await _mdmDbContext.ObjectTopics.AddAsync(objectTopic);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectTopic(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectTopic>> UpdateObjectTopic(ObjectTopic objectTopic)
    {
        var res = _mdmDbContext.ObjectTopics.Update(objectTopic);
        await _mdmDbContext.SaveChangesAsync();

        return await GetObjectTopic(res.Entity.Id);
    }

    public async Task<BaseResponse<ObjectTopic>> BulkCreateObjectTopic(ObjectTopic[] objectTopics)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectTopic>> BulkUpdateObjectTopic(ObjectTopic[] objectTopics)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectTopic(int id)
    {
        var data = await GetObjectTopic(id);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectTopics.RemoveRange(data.Data);
        await _mdmDbContext.SaveChangesAsync();
        
        return data.Total;
    }

    public async Task<int> DeleteAllObjectTopics(string sdOid)
    {
        var data = await GetObjectTopics(sdOid);
        
        if (data.Total == 0 && data.Data.Length == 0) return data.Total;
        
        _mdmDbContext.ObjectTopics.RemoveRange(data.Data);
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

    public async Task<BaseResponse<DataObject>> PaginateDataObjects(PaginationRequest paginationRequest)
    {
        var skip = CalculateSkip(paginationRequest.Page, paginationRequest.Size);
            
        var query = _mdmDbContext.DataObjects
            .AsNoTracking()
            .OrderBy(arg => arg.Id);
            
        var data = await query.Skip(skip).Take(paginationRequest.Size).ToArrayAsync();

        var total = await query.CountAsync();
        
        return new BaseResponse<DataObject>
        {
            Total = total,
            Data = data
        };
    }

    public async Task<BaseResponse<DataObject>> FilterDataObjectsByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        var skip = CalculateSkip(filteringByTitleRequest.Page, filteringByTitleRequest.Size);
            
        var query = _mdmDbContext.DataObjects
            .AsNoTracking()
            .Where(p => p.DisplayTitle!.ToLower().Contains(filteringByTitleRequest.Title.ToLower()))
            .OrderBy(arg => arg.Id);

        var data = await query
            .Skip(skip)
            .Take(filteringByTitleRequest.Size)
            .ToArrayAsync();

        var total = await query.CountAsync();

        return new BaseResponse<DataObject>
        {
            Total = total,
            Data = data
        };
    }

    public async Task<int> GetTotalDataObjects()
    {
        return await _mdmDbContext.DataObjects.AsNoTracking().CountAsync();
    }
}