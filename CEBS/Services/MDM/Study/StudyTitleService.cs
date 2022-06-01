using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;

namespace CEBS.Services.MDM.Study;

public class StudyTitleService : IStudyTitleService
{
    public async Task<BaseResponse<StudyTitleDto>> GetStudyTitles(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTitleDto>> GetStudyTitle(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTitleDto>> CreateStudyTitle(StudyTitleDto studyTitleDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTitleDto>> UpdateStudyTitle(StudyTitleDto studyTitleDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyTitle(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyTitles(string sdSid)
    {
        throw new NotImplementedException();
    }
}