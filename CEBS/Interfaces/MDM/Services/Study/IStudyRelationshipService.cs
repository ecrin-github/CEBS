using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;

namespace CEBS.Interfaces.MDM.Services.Study;

public interface IStudyRelationshipService
{
    // Study relationships
    Task<BaseResponse<StudyRelationshipDto>> GetStudyRelationships(string sdSid);
    Task<BaseResponse<StudyRelationshipDto>> GetStudyRelationship(int id);
    Task<BaseResponse<StudyRelationshipDto>> CreateStudyRelationship(StudyRelationshipDto studyRelationshipDto);
    Task<BaseResponse<StudyRelationshipDto>> UpdateStudyRelationship(StudyRelationshipDto studyRelationshipDto);
    Task<int> DeleteStudyRelationship(int id);
    Task<int> DeleteAllStudyRelationships(string sdSid);
}