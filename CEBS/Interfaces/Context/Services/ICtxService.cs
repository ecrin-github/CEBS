using CEBS.Contracts.Responses;
using CEBS.Models.Context.Ctx;

namespace CEBS.Interfaces.Context.Services;

public interface ICtxService
{
    Task<BaseResponse<Organisation>> GetOrganisations();
    Task<BaseResponse<Organisation>> GetOrganisation(int id);
    Task<BaseResponse<Organisation>> GetOrganisationsByName(string name);
        
    Task<BaseResponse<OrgAttribute>> GetOrgAttributes(int orgId);
    Task<BaseResponse<OrgLink>> GetOrgLinks(int orgId);
    Task<BaseResponse<OrgLocation>> GetOrgLocations(int orgId);
    Task<BaseResponse<OrgName>> GetOrgNames(int orgId);
    Task<BaseResponse<OrgRelationship>> GetOrgRelationships(int orgId);
    Task<BaseResponse<OrgTypeMembership>> GetOrgTypeMemberships(int orgId);
        
    Task<BaseResponse<People>> GetPeople();
    Task<BaseResponse<People>> GetPerson(int id);
    Task<BaseResponse<PeopleLink>> GetPersonLinks(int personId);
    Task<BaseResponse<PeopleRole>> GetPersonRoles(int personId);
        
    Task<BaseResponse<GeogEntity>> GetGeogEntities();
    Task<BaseResponse<GeogEntity>> GetGeogEntity(int id);

    Task<BaseResponse<PublishedJournal>> GetPublishedJournals();
    Task<BaseResponse<PublishedJournal>> GetPublishedJournal(int id);
}