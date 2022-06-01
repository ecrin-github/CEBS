using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectRelationshipService : IObjectRelationshipService
{
    public async Task<BaseResponse<ObjectRelationshipDto>> GetObjectRelationships(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectRelationshipDto>> GetObjectRelationship(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectRelationshipDto>> CreateObjectRelationship(ObjectRelationshipDto objectRelationshipDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectRelationshipDto>> UpdateObjectRelationship(ObjectRelationshipDto objectRelationshipDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectRelationship(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectRelationships(string sdOid)
    {
        throw new NotImplementedException();
    }
}