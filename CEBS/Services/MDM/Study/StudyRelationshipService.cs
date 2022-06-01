using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;

namespace CEBS.Services.MDM.Study;

public class StudyRelationshipService : IStudyRelationshipService
{
    public async Task<BaseResponse<StudyRelationshipDto>> GetStudyRelationships(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyRelationshipDto>> GetStudyRelationship(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyRelationshipDto>> CreateStudyRelationship(StudyRelationshipDto studyRelationshipDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyRelationshipDto>> UpdateStudyRelationship(StudyRelationshipDto studyRelationshipDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyRelationship(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyRelationships(string sdSid)
    {
        throw new NotImplementedException();
    }
}