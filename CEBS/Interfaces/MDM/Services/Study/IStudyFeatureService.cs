using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;

namespace CEBS.Interfaces.MDM.Services.Study;

public interface IStudyFeatureService
{
    // Study features
    Task<BaseResponse<StudyFeatureDto>> GetStudyFeatures(string sdSid);
    Task<BaseResponse<StudyFeatureDto>> GetStudyFeature(int id);
    Task<BaseResponse<StudyFeatureDto>> CreateStudyFeature(StudyFeatureDto studyFeatureDto);
    Task<BaseResponse<StudyFeatureDto>> UpdateStudyFeature(StudyFeatureDto studyFeatureDto);
    Task<int> DeleteStudyFeature(int id);
    Task<int> DeleteAllStudyFeatures(string sdSid);
}