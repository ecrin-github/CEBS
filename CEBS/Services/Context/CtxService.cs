using CEBS.Contracts.Responses;
using CEBS.Interfaces.Context.Services;
using CEBS.Models.Context.Ctx;

namespace CEBS.Services.Context;

public class CtxService : ICtxService
{
    public async Task<BaseResponse<Organisation>> GetOrganisations()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Organisation>> GetOrganisation(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<Organisation>> GetOrganisationsByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<OrgAttribute>> GetOrgAttributes(int orgId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<OrgLink>> GetOrgLinks(int orgId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<OrgLocation>> GetOrgLocations(int orgId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<OrgName>> GetOrgNames(int orgId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<OrgRelationship>> GetOrgRelationships(int orgId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<OrgTypeMembership>> GetOrgTypeMemberships(int orgId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<People>> GetPeople()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<People>> GetPerson(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<PeopleLink>> GetPersonLinks(int personId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<PeopleRole>> GetPersonRoles(int personId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GeogEntity>> GetGeogEntities()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GeogEntity>> GetGeogEntity(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<PublishedJournal>> GetPublishedJournals()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<PublishedJournal>> GetPublishedJournal(int id)
    {
        throw new NotImplementedException();
    }
}