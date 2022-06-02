using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Models.MDM.Object;
using CEBS.Models.MDM.Study;

namespace CEBS.Interfaces.Mapping;

public interface IMdmMapping
{
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
}