using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDM.DTO.v1.Object;

namespace CEBS.Interfaces.MDM.Services.Object;

public interface IObjectTopicService
{
    Task<BaseResponse<ObjectTopicDto>> GetObjectTopics(string sdOid);
    Task<BaseResponse<ObjectTopicDto>> GetObjectTopic(int id);
    Task<BaseResponse<ObjectTopicDto>> CreateObjectTopic(ObjectTopicDto objectTopicDto);
    Task<BaseResponse<ObjectTopicDto>> UpdateObjectTopic(ObjectTopicDto objectTopicDto);
    Task<int> DeleteObjectTopic(int id);
    Task<int> DeleteAllObjectTopics(string sdOid);
}