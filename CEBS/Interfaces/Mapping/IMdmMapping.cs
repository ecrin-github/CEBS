using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Models.MDM.Object;
using CEBS.Models.MDM.Study;

namespace CEBS.Interfaces.Mapping;

public interface IMdmMapping
{
    StudyDto[] StudyDtoBuilder(Study[] studies);
    StudyDto StudyDtoMapper(Study study);
    StudyDataDto[] StudyDataDtoBuilder(Study[] studies);
    StudyDataDto StudyDataDtoMapper(Study study);

    StudyContributorDto[] StudyContributorDtoBuilder(StudyContributor[] studyContributors);
    StudyContributorDto StudyContributorDtoMapper(StudyContributor studyContributor);

    StudyFeatureDto[] StudyFeatureDtoBuilder(StudyFeature[] studyFeatures);
    StudyFeatureDto StudyFeatureDtoMapper(StudyFeature studyFeature);

    StudyIdentifierDto[] StudyIdentifierDtoBuilder(StudyIdentifier[] studyIdentifiers);
    StudyIdentifierDto StudyIdentifierDtoMapper(StudyIdentifier studyIdentifier);

    StudyReferenceDto[] StudyReferenceDtoBuilder(StudyReference[] studyReferences);
    StudyReferenceDto StudyReferenceDtoMapper(StudyReference studyReference);

    StudyRelationshipDto[] StudyRelationshipDtoBuilder(StudyRelationship[] studyRelationships);
    StudyRelationshipDto StudyRelationshipDtoMapper(StudyRelationship studyRelationship);

    StudyTitleDto[] StudyTitleDtoBuilder(StudyTitle[] studyTitles);
    StudyTitleDto StudyTitleDtoMapper(StudyTitle studyTitle);

    StudyTopicDto[] StudyTopicDtoBuilder(StudyTopic[] studyTopics);
    StudyTopicDto StudyTopicDtoMapper(StudyTopic studyTopic);


    // Data object related data
    DataObjectDto[] DataObjectDtoBuilder(DataObject[] dataObjects);
    DataObjectDto DataObjectDtoMapper(DataObject dataObject);
    DataObjectDataDto[] DataObjectDataDtoBuilder(DataObject[] dataObjects);
    DataObjectDataDto DataObjectDataDtoMapper(DataObject dataObject);

    ObjectContributorDto[] ObjectContributorDtoBuilder(ObjectContributor[] objectContributors);
    ObjectContributorDto ObjectContributorDtoMapper(ObjectContributor objectContributor);

    ObjectDatasetDto[] ObjectDatasetDtoBuilder(ObjectDataset[] objectDatasets);
    ObjectDatasetDto ObjectDatasetDtoMapper(ObjectDataset objectDataset);

    ObjectDateDto[] ObjectDateDtoBuilder(ObjectDate[] objectDates);
    ObjectDateDto ObjectDateDtoMapper(ObjectDate objectDate);

    ObjectDescriptionDto[] ObjectDescriptionDtoBuilder(ObjectDescription[] objectDescriptions);
    ObjectDescriptionDto ObjectDescriptionDtoMapper(ObjectDescription objectDescription);

    ObjectIdentifierDto[] ObjectIdentifierDtoBuilder(ObjectIdentifier[] objectIdentifiers);
    ObjectIdentifierDto ObjectIdentifierDtoMapper(ObjectIdentifier objectIdentifier);

    ObjectInstanceDto[] ObjectInstanceDtoBuilder(ObjectInstance[] objectInstances);
    ObjectInstanceDto ObjectInstanceDtoMapper(ObjectInstance objectInstance);

    ObjectRelationshipDto[] ObjectRelationshipDtoBuilder(ObjectRelationship[] objectRelationships);
    ObjectRelationshipDto ObjectRelationshipDtoMapper(ObjectRelationship objectRelationship);

    ObjectRightDto[] ObjectRightDtoBuilder(ObjectRight[] objectRights);
    ObjectRightDto ObjectRightDtoMapper(ObjectRight objectRight);

    ObjectTitleDto[] ObjectTitleDtoBuilder(ObjectTitle[] objectTitles);
    ObjectTitleDto ObjectTitleDtoMapper(ObjectTitle objectTitle);

    ObjectTopicDto[] ObjectTopicDtoBuilder(ObjectTopic[] objectTopics);
    ObjectTopicDto ObjectTopicDtoMapper(ObjectTopic objectTopic);
    
    
    // Reverse mapping
    Study[] ReverseStudyDtoBuilder(StudyDto[] studyDtos);
    Study ReverseStudyDtoMapper(StudyDto studyDto);
    Study[] ReverseStudyDataDtoBuilder(StudyDataDto[] studyDataDtos);
    Study ReverseStudyDataDtoMapper(StudyDataDto studyDataDto);

    StudyContributor[] ReverseStudyContributorDtoBuilder(StudyContributorDto[] studyContributorDtos);
    StudyContributor ReverseStudyContributorDtoMapper(StudyContributorDto studyContributorDto);

    StudyFeature[] ReverseStudyFeatureDtoBuilder(StudyFeatureDto[] studyFeatureDtos);
    StudyFeature ReverseStudyFeatureDtoMapper(StudyFeatureDto studyFeatureDto);

    StudyIdentifier[] ReverseStudyIdentifierDtoBuilder(StudyIdentifierDto[] studyIdentifierDto);
    StudyIdentifier ReverseStudyIdentifierDtoMapper(StudyIdentifierDto studyIdentifier);

    StudyReference[] ReverseStudyReferenceDtoBuilder(StudyReferenceDto[] studyReferenceDto);
    StudyReference ReverseStudyReferenceDtoMapper(StudyReferenceDto studyReferenceDto);

    StudyRelationship[] ReverseStudyRelationshipDtoBuilder(StudyRelationshipDto[] studyRelationshipDtos);
    StudyRelationship ReverseStudyRelationshipDtoMapper(StudyRelationshipDto studyRelationshipDto);

    StudyTitle[] ReverseStudyTitleDtoBuilder(StudyTitleDto[] studyTitleDtos);
    StudyTitle ReverseStudyTitleDtoMapper(StudyTitleDto studyTitleDto);

    StudyTopic[] ReverseStudyTopicDtoBuilder(StudyTopicDto[] studyTopicDtos);
    StudyTopic ReverseStudyTopicDtoMapper(StudyTopicDto studyTopicDto);


    // Data object related data
    DataObject[] ReverseDataObjectDtoBuilder(DataObjectDto[] dataObjectDtos);
    DataObject ReverseDataObjectDtoMapper(DataObjectDto dataObjectDto);
    DataObject[] ReverseDataObjectDataDtoBuilder(DataObjectDataDto[] dataObjectDataDtos);
    DataObject ReverseDataObjectDataDtoMapper(DataObjectDataDto dataObjectDataDto);

    ObjectContributor[] ReverseObjectContributorDtoBuilder(ObjectContributorDto[] objectContributorsDto);
    ObjectContributor ReverseObjectContributorDtoMapper(ObjectContributorDto objectContributorDto);

    ObjectDataset[] ReverseObjectDatasetDtoBuilder(ObjectDatasetDto[] objectDatasetsDto);
    ObjectDataset ReverseObjectDatasetDtoMapper(ObjectDatasetDto objectDatasetDto);

    ObjectDate[] ReverseObjectDateDtoBuilder(ObjectDateDto[] objectDatesDto);
    ObjectDate ReverseObjectDateDtoMapper(ObjectDateDto objectDateDto);

    ObjectDescription[] ReverseObjectDescriptionDtoBuilder(ObjectDescriptionDto[] objectDescriptionsDto);
    ObjectDescription ReverseObjectDescriptionDtoMapper(ObjectDescriptionDto objectDescriptionDto);

    ObjectIdentifier[] ReverseObjectIdentifierDtoBuilder(ObjectIdentifierDto[] objectIdentifiersDto);
    ObjectIdentifier ReverseObjectIdentifierDtoMapper(ObjectIdentifierDto objectIdentifierDto);

    ObjectInstance[] ReverseObjectInstanceDtoBuilder(ObjectInstanceDto[] objectInstancesDto);
    ObjectInstance ReverseObjectInstanceDtoMapper(ObjectInstanceDto objectInstanceDto);

    ObjectRelationship[] ReverseObjectRelationshipDtoBuilder(ObjectRelationshipDto[] objectRelationshipsDto);
    ObjectRelationship ReverseObjectRelationshipDtoMapper(ObjectRelationshipDto objectRelationshipDto);

    ObjectRight[] ReverseObjectRightDtoBuilder(ObjectRightDto[] objectRightsDto);
    ObjectRight ReverseObjectRightDtoMapper(ObjectRightDto objectRightDto);

    ObjectTitle[] ReverseObjectTitleDtoBuilder(ObjectTitleDto[] objectTitlesDto);
    ObjectTitle ReverseObjectTitleDtoMapper(ObjectTitleDto objectTitleDto);

    ObjectTopic[] ReverseObjectTopicDtoBuilder(ObjectTopicDto[] objectTopicsDto);
    ObjectTopic ReverseObjectTopicDtoMapper(ObjectTopicDto objectTopicDto);
}