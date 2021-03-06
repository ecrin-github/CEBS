using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Models.MDM.Object;

namespace CEBS.Interfaces.MDM.Repositories;

public interface IObjectRepository
{
    // Data objects
    Task<BaseResponse<DataObject>> GetDataObjects();
    Task<BaseResponse<DataObject>> GetObjectById(int id);
    Task<BaseResponse<DataObject>> GetObjectBySdOid(string sdOid);
    Task<BaseResponse<DataObject>> CreateDataObject(DataObject dataObject);
    Task<BaseResponse<DataObject>> UpdateDataObject(DataObject dataObject);
    Task<BaseResponse<DataObject>> BulkCreateDataObject(DataObject[] dataObjects);
    Task<BaseResponse<DataObject>> BulkUpdateDataObject(DataObject[] dataObjects);
    Task<int> DeleteDataObject(string sdOid);

    // Object contributors
    Task<BaseResponse<ObjectContributor>> GetObjectContributors(string sdOid);
    Task<BaseResponse<ObjectContributor>> GetObjectContributor(int id);
    Task<BaseResponse<ObjectContributor>> CreateObjectContributor(ObjectContributor objectContributor);
    Task<BaseResponse<ObjectContributor>> UpdateObjectContributor(ObjectContributor objectContributor);
    Task<BaseResponse<ObjectContributor>> BulkCreateObjectContributor(ObjectContributor[] objectContributors);
    Task<BaseResponse<ObjectContributor>> BulkUpdateObjectContributor(ObjectContributor[] objectContributors);
    Task<int> DeleteObjectContributor(int id);
    Task<int> DeleteAllObjectContributors(string sdOid);

    // Object datasets
    Task<BaseResponse<ObjectDataset>> GetObjectDatasets(string sdOid);
    Task<BaseResponse<ObjectDataset>> GetObjectDataset(int id);
    Task<BaseResponse<ObjectDataset>> CreateObjectDataset(ObjectDataset objectDataset);
    Task<BaseResponse<ObjectDataset>> UpdateObjectDataset(ObjectDataset objectDataset);
    Task<BaseResponse<ObjectDataset>> BulkCreateObjectDataset(ObjectDataset[] objectDatasets);
    Task<BaseResponse<ObjectDataset>> BulkUpdateObjectDataset(ObjectDataset[] objectDatasets);
    Task<int> DeleteObjectDataset(int id);
    Task<int> DeleteAllObjectDatasets(string sdOid);

    // Object dates
    Task<BaseResponse<ObjectDate>> GetObjectDates(string sdOid);
    Task<BaseResponse<ObjectDate>> GetObjectDate(int id);
    Task<BaseResponse<ObjectDate>> CreateObjectDate(ObjectDate objectDate);
    Task<BaseResponse<ObjectDate>> UpdateObjectDate(ObjectDate objectDate);
    Task<BaseResponse<ObjectDate>> BulkCreateObjectDate(ObjectDate[] objectDates);
    Task<BaseResponse<ObjectDate>> BulkUpdateObjectDate(ObjectDate[] objectDates);
    Task<int> DeleteObjectDate(int id);
    Task<int> DeleteAllObjectDates(string sdOid);

    // Object descriptions
    Task<BaseResponse<ObjectDescription>> GetObjectDescriptions(string sdOid);
    Task<BaseResponse<ObjectDescription>> GetObjectDescription(int id);
    Task<BaseResponse<ObjectDescription>> CreateObjectDescription(ObjectDescription objectDescription);
    Task<BaseResponse<ObjectDescription>> UpdateObjectDescription(ObjectDescription objectDescription);
    Task<BaseResponse<ObjectDescription>> BulkCreateObjectDescription(ObjectDescription[] objectDescriptions);
    Task<BaseResponse<ObjectDescription>> BulkUpdateObjectDescription(ObjectDescription[] objectDescriptions);
    Task<int> DeleteObjectDescription(int id);
    Task<int> DeleteAllObjectDescriptions(string sdOid);

    // Object identifiers
    Task<BaseResponse<ObjectIdentifier>> GetObjectIdentifiers(string sdOid);
    Task<BaseResponse<ObjectIdentifier>> GetObjectIdentifier(int id);
    Task<BaseResponse<ObjectIdentifier>> CreateObjectIdentifier(ObjectIdentifier objectIdentifier);
    Task<BaseResponse<ObjectIdentifier>> UpdateObjectIdentifier(ObjectIdentifier objectIdentifier);
    Task<BaseResponse<ObjectIdentifier>> BulkCreateObjectIdentifier(ObjectIdentifier[] objectIdentifiers);
    Task<BaseResponse<ObjectIdentifier>> BulkUpdateObjectIdentifier(ObjectIdentifier[] objectIdentifiers);
    Task<int> DeleteObjectIdentifier(int id);
    Task<int> DeleteAllObjectIdentifiers(string sdOid);

    // Object instances
    Task<BaseResponse<ObjectInstance>> GetObjectInstances(string sdOid);
    Task<BaseResponse<ObjectInstance>> GetObjectInstance(int id);
    Task<BaseResponse<ObjectInstance>> CreateObjectInstance(ObjectInstance objectInstance);
    Task<BaseResponse<ObjectInstance>> UpdateObjectInstance(ObjectInstance objectInstance);
    Task<BaseResponse<ObjectInstance>> BulkCreateObjectInstance(ObjectInstance[] objectInstances);
    Task<BaseResponse<ObjectInstance>> BulkUpdateObjectInstance(ObjectInstance[] objectInstances);
    Task<int> DeleteObjectInstance(int id);
    Task<int> DeleteAllObjectInstances(string sdOid);

    // Object relationships
    Task<BaseResponse<ObjectRelationship>> GetObjectRelationships(string sdOid);
    Task<BaseResponse<ObjectRelationship>> GetObjectRelationship(int id);
    Task<BaseResponse<ObjectRelationship>> CreateObjectRelationship(ObjectRelationship objectRelationship);
    Task<BaseResponse<ObjectRelationship>> UpdateObjectRelationship(ObjectRelationship objectRelationship);
    Task<BaseResponse<ObjectRelationship>> BulkCreateObjectRelationship(ObjectRelationship[] objectRelationships);
    Task<BaseResponse<ObjectRelationship>> BulkUpdateObjectRelationship(ObjectRelationship[] objectRelationships);
    Task<int> DeleteObjectRelationship(int id);
    Task<int> DeleteAllObjectRelationships(string sdOid);

    // Object rights
    Task<BaseResponse<ObjectRight>> GetObjectRights(string sdOid);
    Task<BaseResponse<ObjectRight>> GetObjectRight(int id);
    Task<BaseResponse<ObjectRight>> CreateObjectRight(ObjectRight objectRight);
    Task<BaseResponse<ObjectRight>> UpdateObjectRight(ObjectRight objectRight);
    Task<BaseResponse<ObjectRight>> BulkCreateObjectRight(ObjectRight[] objectRights);
    Task<BaseResponse<ObjectRight>> BulkUpdateObjectRight(ObjectRight[] objectRights);
    Task<int> DeleteObjectRight(int id);
    Task<int> DeleteAllObjectRights(string sdOid);

    // Object titles
    Task<BaseResponse<ObjectTitle>> GetObjectTitles(string sdOid);
    Task<BaseResponse<ObjectTitle>> GetObjectTitle(int id);
    Task<BaseResponse<ObjectTitle>> CreateObjectTitle(ObjectTitle objectTitle);
    Task<BaseResponse<ObjectTitle>> UpdateObjectTitle(ObjectTitle objectTitle);
    Task<BaseResponse<ObjectTitle>> BulkCreateObjectTitle(ObjectTitle[] objectTitles);
    Task<BaseResponse<ObjectTitle>> BulkUpdateObjectTitle(ObjectTitle[] objectTitles);
    Task<int> DeleteObjectTitle(int id);
    Task<int> DeleteAllObjectTitles(string sdOid);


    // Object topics
    Task<BaseResponse<ObjectTopic>> GetObjectTopics(string sdOid);
    Task<BaseResponse<ObjectTopic>> GetObjectTopic(int id);
    Task<BaseResponse<ObjectTopic>> CreateObjectTopic(ObjectTopic objectTopic);
    Task<BaseResponse<ObjectTopic>> UpdateObjectTopic(ObjectTopic objectTopic);
    Task<BaseResponse<ObjectTopic>> BulkCreateObjectTopic(ObjectTopic[] objectTopics);
    Task<BaseResponse<ObjectTopic>> BulkUpdateObjectTopic(ObjectTopic[] objectTopics);
    Task<int> DeleteObjectTopic(int id);
    Task<int> DeleteAllObjectTopics(string sdOid);

    // Extensions
    Task<BaseResponse<DataObject>> PaginateDataObjects(PaginationRequest paginationRequest);
    Task<BaseResponse<DataObject>> FilterDataObjectsByTitle(FilteringByTitleRequest filteringByTitleRequest);
    Task<int> GetTotalDataObjects();
}