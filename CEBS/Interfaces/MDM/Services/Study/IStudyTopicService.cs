using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;

namespace CEBS.Interfaces.MDM.Services.Study;

public interface IStudyTopicService
{
    // Study topics
    Task<BaseResponse<StudyTopicDto>> GetStudyTopics(string sdSid);
    Task<BaseResponse<StudyTopicDto>> GetStudyTopic(int id);
    Task<BaseResponse<StudyTopicDto>> CreateStudyTopic(StudyTopicDto studyTopicDto);
    Task<BaseResponse<StudyTopicDto>> UpdateStudyTopic(StudyTopicDto studyTopicDto);
    Task<int> DeleteStudyTopic(int id);
    Task<int> DeleteAllStudyTopics(string sdSid);
}