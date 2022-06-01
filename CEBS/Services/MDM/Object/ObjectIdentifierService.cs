using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectIdentifierService : IObjectIdentifierService
{
    public async Task<BaseResponse<ObjectIdentifierDto>> GetObjectIdentifiers(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectIdentifierDto>> GetObjectIdentifier(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectIdentifierDto>> CreateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectIdentifierDto>> UpdateObjectIdentifier(ObjectIdentifierDto objectIdentifierDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectIdentifier(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectIdentifiers(string sdOid)
    {
        throw new NotImplementedException();
    }
}