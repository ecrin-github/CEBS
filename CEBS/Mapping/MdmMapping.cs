using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.Mapping;
using CEBS.Models.MDM.Object;
using CEBS.Models.MDM.Study;

namespace CEBS.Mapping;

public class MdmMapping : IMdmMapping
{
    public StudyDataDto[] StudyDataDtoBuilder(Study[] studies)
    {
        return studies.Select(StudyDataDtoMapper).ToArray();
    }

    public StudyDataDto StudyDataDtoMapper(Study study)
    {
        var studyDataDto = new StudyDataDto()
        {
            Id = study.Id,
            SdSid = study.SdSid,
            MdrSdSid = study.MdrSdSid,
            MdrSourceId = study.MdrSourceId,
            DisplayTitle = study.DisplayTitle,
            TitleLangCode = study.TitleLangCode,
            BriefDescription = study.BriefDescription,
            DataSharingStatement = study.DataSharingStatement,
            StudyStartYear = study.StudyStartYear,
            StudyStartMonth = study.StudyStartMonth,
            StudyTypeId = study.StudyTypeId,
            StudyStatusId = study.StudyStatusId,
            StudyEnrolment = study.StudyEnrolment,
            StudyGenderEligId = study.StudyGenderEligId,
            MinAge = study.MinAge,
            MinAgeUnitsId = study.MinAgeUnitsId,
            MaxAge = study.MaxAge,
            MaxAgeUnitsId = study.MaxAgeUnitsId,
            CreatedOn = study.CreatedOn.ToString()
        };
        return studyDataDto;
    }

    public StudyContributorDto[] StudyContributorDtoBuilder(StudyContributor[] studyContributors)
    {
        return studyContributors.Select(StudyContributorDtoMapper).ToArray();
    }

    public StudyContributorDto StudyContributorDtoMapper(StudyContributor studyContributor)
    {
        var studyContributorDto = new StudyContributorDto
        {
            Id = studyContributor.Id,
            SdSid = studyContributor.SdSid,
            ContribTypeId = studyContributor.ContribTypeId,
            IsIndividual = studyContributor.IsIndividual,
            PersonId = studyContributor.PersonId,
            PersonGivenName = studyContributor.PersonGivenName,
            PersonFamilyName = studyContributor.PersonFamilyName,
            PersonFullName = studyContributor.PersonFullName,
            PersonAffiliation = studyContributor.PersonAffiliation,
            OrganisationId = studyContributor.OrganisationId,
            OrganisationName = studyContributor.OrganisationName,
            OrganisationRorId = studyContributor.OrganisationRorId,
            CreatedOn = studyContributor.CreatedOn
        };

        return studyContributorDto;
    }

    public StudyFeatureDto[] StudyFeatureDtoBuilder(StudyFeature[] studyFeatures)
    {
        return studyFeatures.Select(StudyFeatureDtoMapper).ToArray();
    }

    public StudyFeatureDto StudyFeatureDtoMapper(StudyFeature studyFeature)
    {
        var studyFeatureDto = new StudyFeatureDto
        {
            Id = studyFeature.Id,
            SdSid = studyFeature.SdSid,
            FeatureTypeId = studyFeature.FeatureTypeId,
            FeatureValueId = studyFeature.FeatureValueId,
            CreatedOn = studyFeature.CreatedOn
        };

        return studyFeatureDto;
    }

    public StudyIdentifierDto[] StudyIdentifierDtoBuilder(StudyIdentifier[] studyIdentifiers)
    {
        return studyIdentifiers.Select(StudyIdentifierDtoMapper).ToArray();
    }

    public StudyIdentifierDto StudyIdentifierDtoMapper(StudyIdentifier studyIdentifier)
    {
        var studyIdentifierDto = new StudyIdentifierDto
        {
            Id = studyIdentifier.Id,
            SdSid = studyIdentifier.SdSid,
            CreatedOn = studyIdentifier.CreatedOn,
            IdentifierTypeId = studyIdentifier.IdentifierTypeId,
            IdentifierValue = studyIdentifier.IdentifierValue,
            IdentifierOrgId = studyIdentifier.IdentifierOrgId,
            IdentifierOrg = studyIdentifier.IdentifierOrg,
            IdentifierOrgRorId = studyIdentifier.IdentifierOrgRorId,
            IdentifierDate = studyIdentifier.IdentifierDate,
            IdentifierLink = studyIdentifier.IdentifierLink
        };

        return studyIdentifierDto;
    }

    public StudyReferenceDto[] StudyReferenceDtoBuilder(StudyReference[] studyReferences)
    {
        return studyReferences.Select(StudyReferenceDtoMapper).ToArray();
    }

    public StudyReferenceDto StudyReferenceDtoMapper(StudyReference studyReference)
    {
        var studyReferenceDto = new StudyReferenceDto
        {
            Id = studyReference.Id,
            SdSid = studyReference.SdSid,
            CreatedOn = studyReference.CreatedOn,
            Pmid = studyReference.Pmid,
            Doi = studyReference.Doi,
            Citation = studyReference.Citation,
            Comments = studyReference.Comments
        };

        return studyReferenceDto;
    }

    public StudyRelationshipDto[] StudyRelationshipDtoBuilder(StudyRelationship[] studyRelationships)
    {
        return studyRelationships.Select(StudyRelationshipDtoMapper).ToArray();
    }

    public StudyRelationshipDto StudyRelationshipDtoMapper(StudyRelationship studyRelationship)
    {
        var studyRelationshipDto = new StudyRelationshipDto
        {
            Id = studyRelationship.Id,
            SdSid = studyRelationship.SdSid,
            CreatedOn = studyRelationship.CreatedOn,
            RelationshipTypeId = studyRelationship.RelationshipTypeId,
            TargetSdSid = studyRelationship.TargetSdSid
        };

        return studyRelationshipDto;
    }

    public StudyTitleDto[] StudyTitleDtoBuilder(StudyTitle[] studyTitles)
    {
        return studyTitles.Select(StudyTitleDtoMapper).ToArray();
    }

    public StudyTitleDto StudyTitleDtoMapper(StudyTitle studyTitle)
    {
        var studyTitleDto = new StudyTitleDto
        {
            Id = studyTitle.Id,
            SdSid = studyTitle.SdSid,
            CreatedOn = studyTitle.CreatedOn,
            IsDefault = studyTitle.IsDefault,
            LangCode = studyTitle.LangCode,
            TitleText = studyTitle.TitleText,
            TitleTypeId = studyTitle.TitleTypeId,
            LangUsageId = studyTitle.LangUsageId,
            Comments = studyTitle.Comments
        };

        return studyTitleDto;
    }

    public StudyTopicDto[] StudyTopicDtoBuilder(StudyTopic[] studyTopics)
    {
        return studyTopics.Select(StudyTopicDtoMapper).ToArray();
    }

    public StudyTopicDto StudyTopicDtoMapper(StudyTopic studyTopic)
    {
        var studyTopicDto = new StudyTopicDto
        {
            Id = studyTopic.Id,
            SdSid = studyTopic.SdSid,
            CreatedOn = studyTopic.CreatedOn,
            TopicTypeId = studyTopic.TopicTypeId,
            MeshCoded = studyTopic.MeshCoded,
            MeshCode = studyTopic.MeshCode,
            MeshValue = studyTopic.MeshValue,
            OriginalCtId = studyTopic.OriginalCtId,
            OriginalCtCode = studyTopic.OriginalCtCode,
            OriginalValue = studyTopic.OriginalValue,
        };

        return studyTopicDto;
    }

    public DataObjectDataDto[] DataObjectDataDtoBuilder(DataObject[] dataObjects)
    {
        return dataObjects.Select(DataObjectDataDtoMapper).ToArray();
    }

    public DataObjectDataDto DataObjectDataDtoMapper(DataObject dataObject)
    {
        var dataObjectDataDto = new DataObjectDataDto()
        {
            Id = dataObject.Id,
            SdOid = dataObject.SdOid,
            SdSid = dataObject.SdSid,
            DisplayTitle = dataObject.DisplayTitle,
            Version = dataObject.Version,
            Doi = dataObject.Doi,
            DoiStatusId = dataObject.DoiStatusId,
            PublicationYear = dataObject.PublicationYear,
            ObjectClassId = dataObject.ObjectClassId,
            ObjectTypeId = dataObject.ObjectTypeId,
            ManagingOrgId = dataObject.ManagingOrgId,
            ManagingOrg = dataObject.ManagingOrg,
            ManagingOrgRorId = dataObject.ManagingOrgRorId,
            LangCode = dataObject.LangCode,
            AccessTypeId = dataObject.AccessTypeId,
            AccessDetails = dataObject.AccessDetails,
            AccessDetailsUrl = dataObject.AccessDetailsUrl,
            UrlLastChecked = dataObject.UrlLastChecked,
            EoscCategory = dataObject.EoscCategory,
            AddStudyContribs = dataObject.AddStudyContribs,
            AddStudyTopics = dataObject.AddStudyTopics,
            CreatedOn = dataObject.CreatedOn
        };
        return dataObjectDataDto;
    }

    public ObjectContributorDto[] ObjectContributorDtoBuilder(ObjectContributor[] objectContributors)
    {
        return objectContributors.Select(ObjectContributorDtoMapper).ToArray();
    }

    public ObjectContributorDto ObjectContributorDtoMapper(ObjectContributor objectContributor)
    {
        var objectContributorDto = new ObjectContributorDto
        {
            Id = objectContributor.Id,
            SdOid = objectContributor.SdOid,
            CreatedOn = objectContributor.CreatedOn,
            ContribTypeId = objectContributor.ContribTypeId,
            IsIndividual = objectContributor.IsIndividual,
            OrganisationId = objectContributor.OrganisationId,
            OrganisationName = objectContributor.OrganisationName,
            PersonId = objectContributor.PersonId,
            PersonFamilyName = objectContributor.PersonFamilyName,
            PersonGivenName = objectContributor.PersonGivenName,
            PersonFullName = objectContributor.PersonFullName,
            PersonAffiliation = objectContributor.PersonAffiliation,
            OrcidId = objectContributor.OrcidId
        };

        return objectContributorDto;
    }

    public ObjectDatasetDto[] ObjectDatasetDtoBuilder(ObjectDataset[] objectDatasets)
    {
        return objectDatasets.Select(ObjectDatasetDtoMapper).ToArray();
    }

    public ObjectDatasetDto ObjectDatasetDtoMapper(ObjectDataset objectDataset)
    {
        var objectDatasetDto = new ObjectDatasetDto
        {
            Id = objectDataset.Id,
            SdOid = objectDataset.SdOid,
            CreatedOn = objectDataset.CreatedOn,
            RecordKeysTypeId = objectDataset.RecordKeysTypeId,
            RecordKeysDetails = objectDataset.RecordKeysDetails,
            DeidentTypeId = objectDataset.DeidentTypeId,
            DeidentHipaa = objectDataset.DeidentHipaa,
            DeidentDirect = objectDataset.DeidentDirect,
            DeidentDates = objectDataset.DeidentDates,
            DeidentNonarr = objectDataset.DeidentNonarr,
            DeidentKanon = objectDataset.DeidentKanon,
            DeidentDetails = objectDataset.DeidentDetails,
            ConsentTypeId = objectDataset.ConsentTypeId,
            ConsentNoncommercial = objectDataset.ConsentNoncommercial,
            ConsentGeogRestrict = objectDataset.ConsentGeogRestrict,
            ConsentGeneticOnly = objectDataset.ConsentGeneticOnly,
            ConsentResearchType = objectDataset.ConsentResearchType,
            ConsentNoMethods = objectDataset.ConsentNoMethods,
            ConsentDetails = objectDataset.ConsentDetails
        };

        return objectDatasetDto;
    }

    public ObjectDateDto[] ObjectDateDtoBuilder(ObjectDate[] objectDates)
    {
        return objectDates.Select(ObjectDateDtoMapper).ToArray();
    }

    public ObjectDateDto ObjectDateDtoMapper(ObjectDate objectDate)
    {
        var objectDateDto = new ObjectDateDto
        {
            Id = objectDate.Id,
            SdOid = objectDate.SdOid,
            CreatedOn = objectDate.CreatedOn,
            DateTypeId = objectDate.DateTypeId,
            DateIsRange = objectDate.DateIsRange,
            DateAsString = objectDate.DateAsString,
            StartYear = objectDate.StartYear,
            StartMonth = objectDate.StartMonth,
            StartDay = objectDate.StartDay,
            EndYear = objectDate.EndYear,
            EndMonth = objectDate.EndMonth,
            EndDay = objectDate.EndDay,
            Details = objectDate.Details
        };

        return objectDateDto;
    }

    public ObjectDescriptionDto[] ObjectDescriptionDtoBuilder(ObjectDescription[] objectDescriptions)
    {
        return objectDescriptions.Select(ObjectDescriptionDtoMapper).ToArray();
    }

    public ObjectDescriptionDto ObjectDescriptionDtoMapper(ObjectDescription objectDescription)
    {
        var objectDescriptionDto = new ObjectDescriptionDto
        {
            Id = objectDescription.Id,
            SdOid = objectDescription.SdOid,
            CreatedOn = objectDescription.CreatedOn,
            DescriptionTypeId = objectDescription.DescriptionTypeId,
            DescriptionText = objectDescription.DescriptionText,
            LangCode = objectDescription.LangCode,
            Label = objectDescription.Label
        };

        return objectDescriptionDto;
    }

    public ObjectIdentifierDto[] ObjectIdentifierDtoBuilder(ObjectIdentifier[] objectIdentifiers)
    {
        return objectIdentifiers.Select(ObjectIdentifierDtoMapper).ToArray();
    }

    public ObjectIdentifierDto ObjectIdentifierDtoMapper(ObjectIdentifier objectIdentifier)
    {
        var objectIdentifierDto = new ObjectIdentifierDto
        {
            Id = objectIdentifier.Id,
            SdOid = objectIdentifier.SdOid,
            CreatedOn = objectIdentifier.CreatedOn,
            IdentifierValue = objectIdentifier.IdentifierValue,
            IdentifierTypeId = objectIdentifier.IdentifierTypeId,
            IdentifierOrg = objectIdentifier.IdentifierOrg,
            IdentifierOrgId = objectIdentifier.IdentifierOrgId,
            IdentifierDate = objectIdentifier.IdentifierDate,
            IdentifierOrgRorId = objectIdentifier.IdentifierOrgRorId
        };

        return objectIdentifierDto;
    }

    public ObjectInstanceDto[] ObjectInstanceDtoBuilder(ObjectInstance[] objectInstances)
    {
        return objectInstances.Select(ObjectInstanceDtoMapper).ToArray();
    }

    public ObjectInstanceDto ObjectInstanceDtoMapper(ObjectInstance objectInstance)
    {
        var objectInstanceDto = new ObjectInstanceDto
        {
            Id = objectInstance.Id,
            SdOid = objectInstance.SdOid,
            CreatedOn = objectInstance.CreatedOn,
            InstanceTypeId = objectInstance.InstanceTypeId,
            RepositoryOrgId = objectInstance.RepositoryOrgId,
            RepositoryOrg = objectInstance.RepositoryOrg,
            Url = objectInstance.Url,
            UrlAccessible = objectInstance.UrlAccessible,
            UrlLastChecked = objectInstance.UrlLastChecked,
            ResourceTypeId = objectInstance.ResourceTypeId,
            ResourceSize = objectInstance.ResourceSize,
            ResourceSizeUnits = objectInstance.ResourceSizeUnits,
            ResourceComments = objectInstance.ResourceComments
        };

        return objectInstanceDto;
    }

    public ObjectRelationshipDto[] ObjectRelationshipDtoBuilder(ObjectRelationship[] objectRelationships)
    {
        return objectRelationships.Select(ObjectRelationshipDtoMapper).ToArray();
    }

    public ObjectRelationshipDto ObjectRelationshipDtoMapper(ObjectRelationship objectRelationship)
    {
        var objectRelationshipDto = new ObjectRelationshipDto
        {
            Id = objectRelationship.Id,
            SdOid = objectRelationship.SdOid,
            CreatedOn = objectRelationship.CreatedOn,
            RelationshipTypeId = objectRelationship.RelationshipTypeId,
            TargetSdOid = objectRelationship.TargetSdOid
        };

        return objectRelationshipDto;
    }

    public ObjectRightDto[] ObjectRightDtoBuilder(ObjectRight[] objectRights)
    {
        return objectRights.Select(ObjectRightDtoMapper).ToArray();
    }

    public ObjectRightDto ObjectRightDtoMapper(ObjectRight objectRight)
    {
        var objectRightDto = new ObjectRightDto
        {
            Id = objectRight.Id,
            SdOid = objectRight.SdOid,
            CreatedOn = objectRight.CreatedOn,
            RightsName = objectRight.RightsName,
            RightsUri = objectRight.RightsUri,
            Comments = objectRight.Comments
        };

        return objectRightDto;
    }

    public ObjectTitleDto[] ObjectTitleDtoBuilder(ObjectTitle[] objectTitles)
    {
        return objectTitles.Select(ObjectTitleDtoMapper).ToArray();
    }

    public ObjectTitleDto ObjectTitleDtoMapper(ObjectTitle objectTitle)
    {
        var objectTitleDto = new ObjectTitleDto
        {
            Id = objectTitle.Id,
            SdOid = objectTitle.SdOid,
            CreatedOn = objectTitle.CreatedOn,
            TitleTypeId = objectTitle.TitleTypeId,
            IsDefault = objectTitle.IsDefault,
            TitleText = objectTitle.TitleText,
            LangCode = objectTitle.LangCode,
            LangUsageId = objectTitle.LangUsageId,
            Comments = objectTitle.Comments
        };

        return objectTitleDto;
    }

    public ObjectTopicDto[] ObjectTopicDtoBuilder(ObjectTopic[] objectTopics)
    {
        return objectTopics.Select(ObjectTopicDtoMapper).ToArray();
    }

    public ObjectTopicDto ObjectTopicDtoMapper(ObjectTopic objectTopic)
    {
        var objectTopicDto = new ObjectTopicDto
        {
            Id = objectTopic.Id,
            SdOid = objectTopic.SdOid,
            CreatedOn = objectTopic.CreatedOn,
            TopicTypeId = objectTopic.TopicTypeId,
            MeshCoded = objectTopic.MeshCoded,
            MeshCode = objectTopic.MeshCode,
            MeshValue = objectTopic.MeshValue,
            OriginalCtId = objectTopic.OriginalCtId,
            OriginalCtCode = objectTopic.OriginalCtCode,
            OriginalValue = objectTopic.OriginalValue,
        };

        return objectTopicDto;
    }
}