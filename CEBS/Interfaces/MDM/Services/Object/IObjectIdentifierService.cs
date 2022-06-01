using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectIdentifierService
{
    // Object identifiers
    Task<BaseResponse<ObjectIdentifierDto>> GetObjectIdentifiers(string sdOid);
    Task<BaseResponse<ObjectIdentifierDto>> GetObjectIdentifier(int id);
    Task<BaseResponse<ObjectIdentifierDto>> CreateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto);
    Task<BaseResponse<ObjectIdentifierDto>> UpdateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto);
    Task<int> DeleteObjectIdentifier(int id);
    Task<int> DeleteAllObjectIdentifiers(string sdOid);
}