using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;

namespace CEBS.Interfaces.MDM.Services.Study;

public interface IStudyTitleService
{
    // Study titles
    Task<BaseResponse<StudyTitleDto>> GetStudyTitles(string sdSid);
    Task<BaseResponse<StudyTitleDto>> GetStudyTitle(int id);
    Task<BaseResponse<StudyTitleDto>> CreateStudyTitle(StudyTitleDto studyTitleDto);
    Task<BaseResponse<StudyTitleDto>> UpdateStudyTitle(StudyTitleDto studyTitleDto);
    Task<int> DeleteStudyTitle(int id);
    Task<int> DeleteAllStudyTitles(string sdSid);
}