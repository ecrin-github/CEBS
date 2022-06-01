using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;

namespace CEBS.Services.MDM.Study;

public class StudyContributorService : IStudyContributorService
{
    public async Task<BaseResponse<StudyContributorDto>> GetStudyContributors(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyContributorDto>> GetStudyContributor(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyContributorDto>> CreateStudyContributor(StudyContributorDto studyContributorDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyContributorDto>> UpdateStudyContributor(StudyContributorDto studyContributorDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyContributor(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyContributors(string sdSid)
    {
        throw new NotImplementedException();
    }
}