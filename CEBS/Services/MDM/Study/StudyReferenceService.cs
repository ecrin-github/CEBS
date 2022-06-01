using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Repositories;
using CEBS.Interfaces.MDM.Services.Study;

namespace CEBS.Services.MDM.Study;

public class StudyReferenceService : IStudyReferenceService
{
    public async Task<BaseResponse<StudyReferenceDto>> GetStudyReferences(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyReferenceDto>> GetStudyReference(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyReferenceDto>> CreateStudyReference(StudyReferenceDto studyReferenceDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyReferenceDto>> UpdateStudyReference(StudyReferenceDto studyReferenceDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyReference(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyReferences(string sdSid)
    {
        throw new NotImplementedException();
    }
}