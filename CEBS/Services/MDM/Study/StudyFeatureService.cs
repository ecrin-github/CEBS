using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;

namespace CEBS.Services.MDM.Study;

public class StudyFeatureService : IStudyFeatureService
{
    public async Task<BaseResponse<StudyFeatureDto>> GetStudyFeatures(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyFeatureDto>> GetStudyFeature(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyFeatureDto>> CreateStudyFeature(StudyFeatureDto studyFeatureDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyFeatureDto>> UpdateStudyFeature(StudyFeatureDto studyFeatureDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyFeature(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyFeatures(string sdSid)
    {
        throw new NotImplementedException();
    }
}