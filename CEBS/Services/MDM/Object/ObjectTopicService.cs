using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Interfaces.MDM.Services.Object;

namespace CEBS.Services.MDM.Object;

public class ObjectTopicService : IObjectTopicService
{
    public async Task<BaseResponse<ObjectTopicDto>> GetObjectTopics(string sdOid)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectTopicDto>> GetObjectTopic(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectTopicDto>> CreateObjectTopic(ObjectTopicDto objectTopicDto)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<ObjectTopicDto>> UpdateObjectTopic(ObjectTopicDto objectTopicDto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteObjectTopic(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAllObjectTopics(string sdOid)
    {
        throw new NotImplementedException();
    }
}