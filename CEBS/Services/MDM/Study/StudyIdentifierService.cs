using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;

namespace CEBS.Services.MDM.Study;

public class StudyIdentifierService : IStudyIdentifierService
{
    public async Task<BaseResponse<StudyIdentifierDto>> GetStudyIdentifiers(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyIdentifierDto>> GetStudyIdentifier(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyIdentifierDto>> CreateStudyIdentifier(StudyIdentifierDto studyIdentifierDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyIdentifierDto>> UpdateStudyIdentifier(StudyIdentifierDto studyIdentifierDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyIdentifier(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyIdentifiers(string sdSid)
    {
        throw new NotImplementedException();
    }
}