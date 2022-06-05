using CEBS.Contracts.Requests.MDM.v1.Filtering;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;

namespace CEBS.Interfaces.MDM.Services.Study;

public interface IStudyService
{
    // Study
    Task<BaseResponse<StudyDto>> GetStudies();
    Task<BaseResponse<StudyDto>> GetStudyBySdSid(string sdSid);
    Task<BaseResponse<StudyDto>> GetStudyById(int id);
    Task<BaseResponse<StudyDto>> CreateStudy(StudyDto studyDto);
    Task<BaseResponse<StudyDto>> UpdateStudy(StudyDto studyDto);
    Task<int> DeleteStudy(string sdSid);
    
    // Extensions
    Task<BaseResponse<StudyDto>> PaginateStudies(PaginationRequest paginationRequest);
    Task<BaseResponse<StudyDto>> FilterStudiesByTitle(FilteringByTitleRequest filteringByTitleRequest);
    Task<int> GetTotalStudies();
}