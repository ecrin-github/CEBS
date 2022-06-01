using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.MDM.Services.Study;

namespace CEBS.Services.MDM.Study;

public class StudyTopicService : IStudyTopicService
{
    public async Task<BaseResponse<StudyTopicDto>> GetStudyTopics(string sdSid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTopicDto>> GetStudyTopic(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTopicDto>> CreateStudyTopic(StudyTopicDto studyTopicDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<StudyTopicDto>> UpdateStudyTopic(StudyTopicDto studyTopicDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteStudyTopic(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllStudyTopics(string sdSid)
    {
        throw new NotImplementedException();
    }
}