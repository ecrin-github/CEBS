using CEBS.Contracts.Responses;
using CEBS.Contracts.Responses.Context.DTO.v1;
using CEBS.Models.Context.Lup;

namespace CEBS.Interfaces.Context.Services;

public interface ILupService
{
    Task<BaseResponse<ContextDto>> GetCompositeHashTypes();
    Task<BaseResponse<ContextDto>> GetCompositeHashType(int id);

    Task<BaseResponse<ContextDto>> GetContributionTypes();
    Task<BaseResponse<ContextDto>> GetContributionType(int id);

    Task<BaseResponse<ContextDto>> GetDatasetConsentTypes();
    Task<BaseResponse<ContextDto>> GetDatasetConsentType(int id);

    Task<BaseResponse<ContextDto>> GetDatasetDeidentLevels();
    Task<BaseResponse<ContextDto>> GetDatasetDeidentLevel(int id);

    Task<BaseResponse<ContextDto>> GetDatasetRecordkeyTypes();
    Task<BaseResponse<ContextDto>> GetDatasetRecordkeyType(int id);

    Task<BaseResponse<ContextDto>> GetDateTypes();
    Task<BaseResponse<ContextDto>> GetDateType(int id);

    Task<BaseResponse<ContextDto>> GetDescriptionTypes();
    Task<BaseResponse<ContextDto>> GetDescriptionType(int id);

    Task<BaseResponse<ContextDto>> GetDoiStatusTypes();
    Task<BaseResponse<ContextDto>> GetDoiStatusType(int id);

    Task<BaseResponse<ContextDto>> GetGenderEligTypes();
    Task<BaseResponse<ContextDto>> GetGenderEligType(int id);

    Task<BaseResponse<ContextDto>> GetGeogEntityTypes();
    Task<BaseResponse<ContextDto>> GetGeogEntityType(int id);

    Task<BaseResponse<ContextDto>> GetIdentifierTypes();
    Task<BaseResponse<ContextDto>> GetIdentifierType(int id);

    Task<BaseResponse<LanguageCode>> GetLanguageCodes();
    Task<BaseResponse<LanguageCode>> GetLanguageCode(string code);

    Task<BaseResponse<ContextDto>> GetLangUsageTypes();
    Task<BaseResponse<ContextDto>> GetLangUsageType(int id);

    Task<BaseResponse<ContextDto>> GetLinkTypes();
    Task<BaseResponse<ContextDto>> GetLinkType(int id);

    Task<BaseResponse<ContextDto>> GetObjectAccessTypes();
    Task<BaseResponse<ContextDto>> GetObjectAccessType(int id);

    Task<BaseResponse<ContextDto>> GetObjectClasses();
    Task<BaseResponse<ContextDto>> GetObjectClass(int id);

    Task<BaseResponse<ContextDto>> GetObjectFilterTypes();
    Task<BaseResponse<ContextDto>> GetObjectFilterType(int id);

    Task<BaseResponse<ContextDto>> GetObjectInstanceTypes();
    Task<BaseResponse<ContextDto>> GetObjectInstanceType(int id);

    Task<BaseResponse<ContextDto>> GetObjectRelationshipTypes();
    Task<BaseResponse<ContextDto>> GetObjectRelationshipType(int id);

    Task<BaseResponse<ContextDto>> GetObjectTypes();
    Task<BaseResponse<ContextDto>> GetObjectType(int id);

    Task<BaseResponse<ContextDto>> GetOrgAttributeDatatypes();
    Task<BaseResponse<ContextDto>> GetOrgAttributeDatatype(int id);

    Task<BaseResponse<ContextDto>> GetOrgAttributeTypes();
    Task<BaseResponse<ContextDto>> GetOrgAttributeType(int id);

    Task<BaseResponse<ContextDto>> GetOrgClasses();
    Task<BaseResponse<ContextDto>> GetOrgClass(int id);

    Task<BaseResponse<ContextDto>> GetOrgLinkTypes();
    Task<BaseResponse<ContextDto>> GetOrgLinkType(int id);

    Task<BaseResponse<ContextDto>> GetOrgNameQualifierTypes();
    Task<BaseResponse<ContextDto>> GetOrgNameQualifierType(int id);

    Task<BaseResponse<ContextDto>> GetOrgRelationshipTypes();
    Task<BaseResponse<ContextDto>> GetOrgRelationshipType(int id);

    Task<BaseResponse<ContextDto>> GetOrgTypes();
    Task<BaseResponse<ContextDto>> GetOrgType(int id);

    Task<BaseResponse<ContextDto>> GetResourceTypes();
    Task<BaseResponse<ContextDto>> GetResourceType(int id);

    Task<BaseResponse<ContextDto>> GetRmsUserTypes();
    Task<BaseResponse<ContextDto>> GetRmsUserType(int id);

    Task<BaseResponse<ContextDto>> GetRoleClasses();
    Task<BaseResponse<ContextDto>> GetRoleClass(int id);

    Task<BaseResponse<ContextDto>> GetRoleTypes();
    Task<BaseResponse<ContextDto>> GetRoleType(int id);

    Task<BaseResponse<ContextDto>> GetSizeUnits();
    Task<BaseResponse<ContextDto>> GetSizeUnit(int id);

    Task<BaseResponse<ContextDto>> GetStudyFeatureCategories();
    Task<BaseResponse<ContextDto>> GetStudyFeatureCategory(int id);

    Task<BaseResponse<ContextDto>> GetStudyFeatureTypes();
    Task<BaseResponse<ContextDto>> GetStudyFeatureType(int id);

    Task<BaseResponse<ContextDto>> GetStudyRelationshipTypes();
    Task<BaseResponse<ContextDto>> GetStudyRelationshipType(int id);

    Task<BaseResponse<ContextDto>> GetStudyStatuses();
    Task<BaseResponse<ContextDto>> GetStudyStatus(int id);

    Task<BaseResponse<ContextDto>> GetStudyTypes();
    Task<BaseResponse<ContextDto>> GetStudyType(int id);

    Task<BaseResponse<ContextDto>> GetTimeUnits();
    Task<BaseResponse<ContextDto>> GetTimeUnit(int id);

    Task<BaseResponse<ContextDto>> GetTitlesTypes();
    Task<BaseResponse<ContextDto>> GetTitleType(int id);

    Task<BaseResponse<ContextDto>> GetTopicTypes();
    Task<BaseResponse<ContextDto>> GetTopicType(int id);

    Task<BaseResponse<ContextDto>> GetTopicVocabularies();
    Task<BaseResponse<ContextDto>> GetTopicVocabulary(int id);
}