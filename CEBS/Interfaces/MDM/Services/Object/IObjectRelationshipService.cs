using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectRelationshipService
{
    // Object relationships
    Task<BaseResponse<ObjectRelationshipDto>> GetObjectRelationships(string sdOid);
    Task<BaseResponse<ObjectRelationshipDto>> GetObjectRelationship(int id);
    Task<BaseResponse<ObjectRelationshipDto>> CreateObjectRelationship(ObjectRelationshipDto objectRelationshipDto);
    Task<BaseResponse<ObjectRelationshipDto>> UpdateObjectRelationship(ObjectRelationshipDto objectRelationshipDto);
    Task<int> DeleteObjectRelationship(int id);
    Task<int> DeleteAllObjectRelationships(string sdOid);
}