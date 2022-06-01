using CEBS.Contracts.Responses;
using CEBS.Interfaces.Context.Repositories;
using CEBS.Models.Context.Rms;

namespace CEBS.Repositories.Context;

public class RmsContextRepository : IRmsContextRepository
{
    public async Task<BaseResponse<AccessPrereqType>> GetAccessPrereqTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<AccessPrereqType>> GetAccessPrereqType(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<CheckStatusType>> GetCheckStatusTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<CheckStatusType>> GetCheckStatusType(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpStatusType>> GetDtpStatusTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DtpStatusType>> GetDtpStatusType(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupStatusType>> GetDupStatusTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<DupStatusType>> GetDupStatusType(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<LegalStatusType>> GetLegalStatusTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<LegalStatusType>> GetLegalStatusType(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<RepoAccessType>> GetRepoAccessTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<RepoAccessType>> GetRepoAccessType(int id)
    {
        throw new NotImplementedException();
    }
}