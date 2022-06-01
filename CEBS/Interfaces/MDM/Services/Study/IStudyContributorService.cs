using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;

namespace CEBS.Interfaces.MDM.Services.Study;

public interface IStudyContributorService
{
    // Study contributors
    Task<BaseResponse<StudyContributorDto>> GetStudyContributors(string sdSid);
    Task<BaseResponse<StudyContributorDto>> GetStudyContributor(int id);
    Task<BaseResponse<StudyContributorDto>> CreateStudyContributor(StudyContributorDto studyContributorDto);
    Task<BaseResponse<StudyContributorDto>> UpdateStudyContributor(StudyContributorDto studyContributorDto);
    Task<int> DeleteStudyContributor(int id);
    Task<int> DeleteAllStudyContributors(string sdSid);
}