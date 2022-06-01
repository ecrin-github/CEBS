using CEBS.Contracts.Responses;
using CEBS.Models.Context.Lup;

namespace CEBS.Interfaces.Context.Repositories;

public interface ILupRepository
{
    Task<BaseResponse<CompositeHashType>> GetCompositeHashTypes();
    Task<BaseResponse<CompositeHashType>> GetCompositeHashType(int id);

    Task<BaseResponse<ContributionType>> GetContributionTypes();
    Task<BaseResponse<ContributionType>> GetContributionType(int id);

    Task<BaseResponse<DatasetConsentType>> GetDatasetConsentTypes();
    Task<BaseResponse<DatasetConsentType>> GetDatasetConsentType(int id);

    Task<BaseResponse<DatasetDeidentificationLevel>> GetDatasetDeidentLevels();
    Task<BaseResponse<DatasetDeidentificationLevel>> GetDatasetDeidentLevel(int id);

    Task<BaseResponse<DatasetRecordkeyType>> GetDatasetRecordkeyTypes();
    Task<BaseResponse<DatasetRecordkeyType>> GetDatasetRecordkeyType(int id);

    Task<BaseResponse<DateType>> GetDateTypes();
    Task<BaseResponse<DateType>> GetDateType(int id);

    Task<BaseResponse<DescriptionType>> GetDescriptionTypes();
    Task<BaseResponse<DescriptionType>> GetDescriptionType(int id);

    Task<BaseResponse<DoiStatusType>> GetDoiStatusTypes();
    Task<BaseResponse<DoiStatusType>> GetDoiStatusType(int id);

    Task<BaseResponse<GenderEligibilityType>> GetGenderEligTypes();
    Task<BaseResponse<GenderEligibilityType>> GetGenderEligType(int id);

    Task<BaseResponse<GeogEntityType>> GetGeogEntityTypes();
    Task<BaseResponse<GeogEntityType>> GetGeogEntityType(int id);

    Task<BaseResponse<IdentifierType>> GetIdentifierTypes();
    Task<BaseResponse<IdentifierType>> GetIdentifierType(int id);

    Task<BaseResponse<LanguageCode>> GetLanguageCodes();
    Task<BaseResponse<LanguageCode>> GetLanguageCode(string code);

    Task<BaseResponse<LanguageUsageType>> GetLangUsageTypes();
    Task<BaseResponse<LanguageUsageType>> GetLangUsageType(int id);

    Task<BaseResponse<LinkType>> GetLinkTypes();
    Task<BaseResponse<LinkType>> GetLinkType(int id);

    Task<BaseResponse<ObjectAccessType>> GetObjectAccessTypes();
    Task<BaseResponse<ObjectAccessType>> GetObjectAccessType(int id);

    Task<BaseResponse<ObjectClass>> GetObjectClasses();
    Task<BaseResponse<ObjectClass>> GetObjectClass(int id);

    Task<BaseResponse<ObjectFilterType>> GetObjectFilterTypes();
    Task<BaseResponse<ObjectFilterType>> GetObjectFilterType(int id);

    Task<BaseResponse<ObjectInstanceType>> GetObjectInstanceTypes();
    Task<BaseResponse<ObjectInstanceType>> GetObjectInstanceType(int id);

    Task<BaseResponse<ObjectRelationshipType>> GetObjectRelationshipTypes();
    Task<BaseResponse<ObjectRelationshipType>> GetObjectRelationshipType(int id);

    Task<BaseResponse<ObjectType>> GetObjectTypes();
    Task<BaseResponse<ObjectType>> GetObjectType(int id);

    Task<BaseResponse<OrgAttributeDatatype>> GetOrgAttributeDatatypes();
    Task<BaseResponse<OrgAttributeDatatype>> GetOrgAttributeDatatype(int id);

    Task<BaseResponse<OrgAttributeType>> GetOrgAttributeTypes();
    Task<BaseResponse<OrgAttributeType>> GetOrgAttributeType(int id);

    Task<BaseResponse<OrgClass>> GetOrgClasses();
    Task<BaseResponse<OrgClass>> GetOrgClass(int id);

    Task<BaseResponse<OrgLinkType>> GetOrgLinkTypes();
    Task<BaseResponse<OrgLinkType>> GetOrgLinkType(int id);

    Task<BaseResponse<OrgNameQualifierType>> GetOrgNameQualifierTypes();
    Task<BaseResponse<OrgNameQualifierType>> GetOrgNameQualifierType(int id);

    Task<BaseResponse<OrgRelationshipType>> GetOrgRelationshipTypes();
    Task<BaseResponse<OrgRelationshipType>> GetOrgRelationshipType(int id);

    Task<BaseResponse<OrgType>> GetOrgTypes();
    Task<BaseResponse<OrgType>> GetOrgType(int id);

    Task<BaseResponse<ResourceType>> GetResourceTypes();
    Task<BaseResponse<ResourceType>> GetResourceType(int id);

    Task<BaseResponse<RmsUserType>> GetRmsUserTypes();
    Task<BaseResponse<RmsUserType>> GetRmsUserType(int id);

    Task<BaseResponse<RoleClass>> GetRoleClasses();
    Task<BaseResponse<RoleClass>> GetRoleClass(int id);

    Task<BaseResponse<RoleType>> GetRoleTypes();
    Task<BaseResponse<RoleType>> GetRoleType(int id);

    Task<BaseResponse<SizeUnit>> GetSizeUnits();
    Task<BaseResponse<SizeUnit>> GetSizeUnit(int id);

    Task<BaseResponse<StudyFeatureCategory>> GetStudyFeatureCategories();
    Task<BaseResponse<StudyFeatureCategory>> GetStudyFeatureCategory(int id);

    Task<BaseResponse<StudyFeatureType>> GetStudyFeatureTypes();
    Task<BaseResponse<StudyFeatureType>> GetStudyFeatureType(int id);

    Task<BaseResponse<StudyRelationshipType>> GetStudyRelationshipTypes();
    Task<BaseResponse<StudyRelationshipType>> GetStudyRelationshipType(int id);

    Task<BaseResponse<StudyStatus>> GetStudyStatuses();
    Task<BaseResponse<StudyStatus>> GetStudyStatus(int id);

    Task<BaseResponse<StudyType>> GetStudyTypes();
    Task<BaseResponse<StudyType>> GetStudyType(int id);

    Task<BaseResponse<TimeUnit>> GetTimeUnits();
    Task<BaseResponse<TimeUnit>> GetTimeUnit(int id);

    Task<BaseResponse<TitleType>> GetTitlesTypes();
    Task<BaseResponse<TitleType>> GetTitleType(int id);

    Task<BaseResponse<TopicType>> GetTopicTypes();
    Task<BaseResponse<TopicType>> GetTopicType(int id);

    Task<BaseResponse<TopicVocabulary>> GetTopicVocabularies();
    Task<BaseResponse<TopicVocabulary>> GetTopicVocabulary(int id);
}