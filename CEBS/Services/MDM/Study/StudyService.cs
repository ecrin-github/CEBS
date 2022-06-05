using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;

namespace CEBS.Services.MDM.Study;

public class StudyService : IStudyService
{
    public async Task<BaseResponse<StudyDto>> GetStudies()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyDto>> GetStudyBySdSid(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyDto>> GetStudyById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyDto>> CreateStudy(StudyDto studyDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyDto>> UpdateStudy(StudyDto studyDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudy(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyDto>> PaginateStudies(PaginationRequest paginationRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyDto>> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetTotalStudies()
    {
        throw new NotImplementedException();
    }
}