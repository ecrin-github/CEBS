using AutoMapper;
using CEBS.Contracts.Responses.Context.DTO.v1;
using CEBS.Models.Context.Lup;

namespace CEBS.Mapping;

public class ContextMapping : Profile
{
    public ContextMapping()
    {
        CreateMap<CompositeHashType, ContextDto>();
        CreateMap<ContributionType, ContextDto>();
        CreateMap<DatasetConsentType, ContextDto>();
        CreateMap<DatasetDeidentificationLevel, ContextDto>();
        CreateMap<DatasetRecordkeyType, ContextDto>();
        CreateMap<DateType, ContextDto>();
        CreateMap<DescriptionType, ContextDto>();
        CreateMap<DoiStatusType, ContextDto>();
        CreateMap<GenderEligibilityType, ContextDto>();
        CreateMap<GeogEntityType, ContextDto>();
        CreateMap<IdentifierType, ContextDto>();
        CreateMap<LanguageUsageType, ContextDto>();
        CreateMap<LinkType, ContextDto>();
        CreateMap<ObjectAccessType, ContextDto>();
        CreateMap<ObjectClass, ContextDto>();
        CreateMap<ObjectFilterType, ContextDto>();
        CreateMap<ObjectInstanceType, ContextDto>();
        CreateMap<ObjectRelationshipType, ContextDto>();
        CreateMap<ObjectType, ContextDto>();
        CreateMap<OrgAttributeDatatype, ContextDto>();
        CreateMap<OrgAttributeType, ContextDto>();
        CreateMap<OrgClass, ContextDto>();
        CreateMap<OrgLinkType, ContextDto>();
        CreateMap<OrgNameQualifierType, ContextDto>();
        CreateMap<OrgRelationshipType, ContextDto>();
        CreateMap<OrgType, ContextDto>();
        CreateMap<ResourceType, ContextDto>();
        CreateMap<RmsUserType, ContextDto>();
        CreateMap<RoleClass, ContextDto>();
        CreateMap<RoleType, ContextDto>();
        CreateMap<SizeUnit, ContextDto>();
        CreateMap<StudyFeatureCategory, ContextDto>();
        CreateMap<StudyFeatureType, ContextDto>();
        CreateMap<StudyRelationshipType, ContextDto>();
        CreateMap<StudyStatus, ContextDto>();
        CreateMap<StudyType, ContextDto>();
        CreateMap<TimeUnit, ContextDto>();
        CreateMap<TitleType, ContextDto>();
        CreateMap<TopicType, ContextDto>();
        CreateMap<TopicVocabulary, ContextDto>();
    }
}