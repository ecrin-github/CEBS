using CEBS.Contracts.Requests.MDR.v1.Elasticsearch;
using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.MDR.DTO.v1.StudyListResponse;

namespace CEBS.Interfaces.MDR.Services;

public interface IElasticsearchService
{
    Task<BaseResponse<StudyListResponse>> GetSpecificStudy(SpecificStudyEsRequest specificStudyRequest);
    Task<BaseResponse<StudyListResponse>> GetByStudyCharacteristics(StudyCharacteristicsEsRequest studyCharacteristicsRequest);
    Task<BaseResponse<StudyListResponse>> GetViaPublishedPaper(ViaPublishedPaperEsRequest viaPublishedPaperRequest);
    Task<BaseResponse<StudyListResponse>> GetByStudyId(StudyIdEsRequest studyIdRequest);
}