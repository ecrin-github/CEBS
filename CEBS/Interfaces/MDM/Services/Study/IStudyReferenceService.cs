using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;

namespace CEBS.Interfaces.MDM.Services.Study;

public interface IStudyReferenceService
{
    // Study references
    Task<BaseResponse<StudyReferenceDto>> GetStudyReferences(string sdSid);
    Task<BaseResponse<StudyReferenceDto>> GetStudyReference(int id);
    Task<BaseResponse<StudyReferenceDto>> CreateStudyReference(StudyReferenceDto studyReferenceDto);
    Task<BaseResponse<StudyReferenceDto>> UpdateStudyReference(StudyReferenceDto studyReferenceDto);
    Task<int> DeleteStudyReference(int id);
    Task<int> DeleteAllStudyReferences(string sdSid);
}