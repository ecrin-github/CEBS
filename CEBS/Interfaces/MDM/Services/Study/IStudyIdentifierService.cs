using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;

namespace CEBS.Interfaces.MDM.Services.Study;

public interface IStudyIdentifierService
{
    // Study identifiers
    Task<BaseResponse<StudyIdentifierDto>> GetStudyIdentifiers(string sdSid);
    Task<BaseResponse<StudyIdentifierDto>> GetStudyIdentifier(int id);
    Task<BaseResponse<StudyIdentifierDto>> CreateStudyIdentifier(StudyIdentifierDto studyIdentifierDto);
    Task<BaseResponse<StudyIdentifierDto>> UpdateStudyIdentifier(StudyIdentifierDto studyIdentifierDto);
    Task<int> DeleteStudyIdentifier(int id);
    Task<int> DeleteAllStudyIdentifiers(string sdSid);
}