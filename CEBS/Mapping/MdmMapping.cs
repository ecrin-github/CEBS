using CEBS.Contracts.Responses.MDM.DTO.v1.Object;
using CEBS.Contracts.Responses.MDM.DTO.v1.Study;
using CEBS.Interfaces.Mapping;
using CEBS.Interfaces.MDM.Services.Object;
using CEBS.Interfaces.MDM.Services.Study;
using CEBS.Models.MDM.Object;
using CEBS.Models.MDM.Study;

namespace CEBS.Mapping;

public class MdmMapping : IMdmMapping
{
    private readonly IObjectContributorService _objectContributorService;
    private readonly IObjectDatasetService _objectDatasetService;
    private readonly IObjectDateService _objectDateService;
    private readonly IObjectDescriptionService _objectDescriptionService;
    private readonly IObjectIdentifierService _objectIdentifierService;
    private readonly IObjectInstanceService _objectInstanceService;
    private readonly IObjectRelationshipService _objectRelationshipService;
    private readonly IObjectRightService _objectRightService;
    private readonly IObjectTitleService _objectTitleService;
    private readonly IObjectTopicService _objectTopicService;

    private readonly IStudyContributorService _studyContributorService;
    private readonly IStudyFeatureService _studyFeatureService;
    private readonly IStudyIdentifierService _studyIdentifierService;
    private readonly IStudyReferenceService _studyReferenceService;
    private readonly IStudyRelationshipService _studyRelationshipService;
    private readonly IStudyTitleService _studyTitleService;
    private readonly IStudyTopicService _studyTopicService;

    public MdmMapping(IObjectContributorService objectContributorService, IObjectDatasetService objectDatasetService,
        IObjectDateService objectDateService, IObjectDescriptionService objectDescriptionService,
        IObjectIdentifierService objectIdentifierService, IObjectInstanceService objectInstanceService,
        IObjectRelationshipService objectRelationshipService, IObjectRightService objectRightService,
        IObjectTitleService objectTitleService, IObjectTopicService objectTopicService,
        IStudyContributorService studyContributorService, IStudyFeatureService studyFeatureService,
        IStudyIdentifierService studyIdentifierService, IStudyReferenceService studyReferenceService,
        IStudyRelationshipService studyRelationshipService, IStudyTitleService studyTitleService,
        IStudyTopicService studyTopicService)
    {
        _objectContributorService = objectContributorService ??
                                    throw new ArgumentNullException(nameof(objectContributorService));
        _objectDatasetService = objectDatasetService ?? throw new ArgumentNullException(nameof(objectDatasetService));
        _objectDateService = objectDateService ?? throw new ArgumentNullException(nameof(objectDateService));
        _objectDescriptionService = objectDescriptionService ??
                                    throw new ArgumentNullException(nameof(objectDescriptionService));
        _objectIdentifierService =
            objectIdentifierService ?? throw new ArgumentNullException(nameof(objectIdentifierService));
        _objectInstanceService =
            objectInstanceService ?? throw new ArgumentNullException(nameof(objectInstanceService));
        _objectRelationshipService = objectRelationshipService ??
                                     throw new ArgumentNullException(nameof(objectRelationshipService));
        _objectRightService = objectRightService ?? throw new ArgumentNullException(nameof(objectRightService));
        _objectTitleService = objectTitleService ?? throw new ArgumentNullException(nameof(objectTitleService));
        _objectTopicService = objectTopicService ?? throw new ArgumentNullException(nameof(objectTopicService));
        _studyContributorService =
            studyContributorService ?? throw new ArgumentNullException(nameof(studyContributorService));
        _studyFeatureService = studyFeatureService ?? throw new ArgumentNullException(nameof(studyFeatureService));
        _studyIdentifierService =
            studyIdentifierService ?? throw new ArgumentNullException(nameof(studyIdentifierService));
        _studyReferenceService =
            studyReferenceService ?? throw new ArgumentNullException(nameof(studyReferenceService));
        _studyRelationshipService = studyRelationshipService ??
                                    throw new ArgumentNullException(nameof(studyRelationshipService));
        _studyTitleService = studyTitleService ?? throw new ArgumentNullException(nameof(studyTitleService));
        _studyTopicService = studyTopicService ?? throw new ArgumentNullException(nameof(studyTopicService));
    }

    public StudyDto[] StudyDtoBuilder(Study[] studies)
    {
        return studies.Select(StudyDtoMapper).ToArray();
    }

    public StudyDto StudyDtoMapper(Study study)
    {
        return new StudyDto
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
            CreatedOn = study.CreatedOn.ToString(),
            StudyContributors = _studyContributorService.GetStudyContributors(study.SdSid!).Result.Data,
            StudyFeatures = _studyFeatureService.GetStudyFeatures(study.SdSid!).Result.Data,
            StudyIdentifiers = _studyIdentifierService.GetStudyIdentifiers(study.SdSid!).Result.Data,
            StudyReferences = _studyReferenceService.GetStudyReferences(study.SdSid!).Result.Data,
            StudyRelationships = _studyRelationshipService.GetStudyRelationships(study.SdSid!).Result.Data,
            StudyTitles = _studyTitleService.GetStudyTitles(study.SdSid!).Result.Data,
            StudyTopics = _studyTopicService.GetStudyTopics(study.SdSid!).Result.Data
        };
    }

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

    public DataObjectDto[] DataObjectDtoBuilder(DataObject[] dataObjects)
    {
        return dataObjects.Select(DataObjectDtoMapper).ToArray();
    }

    public DataObjectDto DataObjectDtoMapper(DataObject dataObject)
    {
        return new DataObjectDto
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
            CreatedOn = dataObject.CreatedOn,
            ObjectContributors = _objectContributorService.GetObjectContributors(dataObject.SdOid!).Result.Data,
            ObjectDatasets = _objectDatasetService.GetObjectDatasets(dataObject.SdOid!).Result.Data[0],
            ObjectDates = _objectDateService.GetObjectDates(dataObject.SdOid!).Result.Data,
            ObjectDescriptions = _objectDescriptionService.GetObjectDescriptions(dataObject.SdOid!).Result.Data,
            ObjectIdentifiers = _objectIdentifierService.GetObjectIdentifiers(dataObject.SdOid!).Result.Data,
            ObjectInstances = _objectInstanceService.GetObjectInstances(dataObject.SdOid!).Result.Data,
            ObjectRelationships = _objectRelationshipService.GetObjectRelationships(dataObject.SdOid!).Result.Data,
            ObjectRights = _objectRightService.GetObjectRights(dataObject.SdOid!).Result.Data,
            ObjectTitles = _objectTitleService.GetObjectTitles(dataObject.SdOid!).Result.Data,
            ObjectTopics = _objectTopicService.GetObjectTopics(dataObject.SdOid!).Result.Data
        };
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

    public Study[] ReverseStudyDtoBuilder(StudyDto[] studyDtos)
    {
        throw new NotImplementedException();
    }

    public Study ReverseStudyDtoMapper(StudyDto studyDto)
    {
        throw new NotImplementedException();
    }

    public Study[] ReverseStudyDataDtoBuilder(StudyDataDto[] studyDataDtos)
    {
        throw new NotImplementedException();
    }

    public Study ReverseStudyDataDtoMapper(StudyDataDto studyDataDto)
    {
        throw new NotImplementedException();
    }

    public StudyContributor[] ReverseStudyContributorDtoBuilder(StudyContributorDto[] studyContributorDtos)
    {
        throw new NotImplementedException();
    }

    public StudyContributor ReverseStudyContributorDtoMapper(StudyContributorDto studyContributorDto)
    {
        throw new NotImplementedException();
    }

    public StudyFeature[] ReverseStudyFeatureDtoBuilder(StudyFeatureDto[] studyFeatureDtos)
    {
        throw new NotImplementedException();
    }

    public StudyFeature ReverseStudyFeatureDtoMapper(StudyFeatureDto studyFeatureDto)
    {
        throw new NotImplementedException();
    }

    public StudyIdentifier[] ReverseStudyIdentifierDtoBuilder(StudyIdentifierDto[] studyIdentifierDto)
    {
        throw new NotImplementedException();
    }

    public StudyIdentifier ReverseStudyIdentifierDtoMapper(StudyIdentifierDto studyIdentifier)
    {
        throw new NotImplementedException();
    }

    public StudyReference[] ReverseStudyReferenceDtoBuilder(StudyReferenceDto[] studyReferenceDto)
    {
        throw new NotImplementedException();
    }

    public StudyReference ReverseStudyReferenceDtoMapper(StudyReferenceDto studyReferenceDto)
    {
        throw new NotImplementedException();
    }

    public StudyRelationship[] ReverseStudyRelationshipDtoBuilder(StudyRelationshipDto[] studyRelationshipDtos)
    {
        throw new NotImplementedException();
    }

    public StudyRelationship ReverseStudyRelationshipDtoMapper(StudyRelationshipDto studyRelationshipDto)
    {
        throw new NotImplementedException();
    }

    public StudyTitle[] ReverseStudyTitleDtoBuilder(StudyTitleDto[] studyTitleDtos)
    {
        throw new NotImplementedException();
    }

    public StudyTitle ReverseStudyTitleDtoMapper(StudyTitleDto studyTitleDto)
    {
        throw new NotImplementedException();
    }

    public StudyTopic[] ReverseStudyTopicDtoBuilder(StudyTopicDto[] studyTopicDtos)
    {
        throw new NotImplementedException();
    }

    public StudyTopic ReverseStudyTopicDtoMapper(StudyTopicDto studyTopicDto)
    {
        throw new NotImplementedException();
    }

    public DataObject[] ReverseDataObjectDtoBuilder(DataObjectDto[] dataObjectDtos)
    {
        throw new NotImplementedException();
    }

    public DataObject ReverseDataObjectDtoMapper(DataObjectDto dataObjectDto)
    {
        throw new NotImplementedException();
    }

    public DataObject[] ReverseDataObjectDataDtoBuilder(DataObjectDataDto[] dataObjectDataDtos)
    {
        throw new NotImplementedException();
    }

    public DataObject ReverseDataObjectDataDtoMapper(DataObjectDataDto dataObjectDataDto)
    {
        throw new NotImplementedException();
    }

    public ObjectContributor[] ReverseObjectContributorDtoBuilder(ObjectContributorDto[] objectContributorsDto)
    {
        throw new NotImplementedException();
    }

    public ObjectContributor ReverseObjectContributorDtoMapper(ObjectContributorDto objectContributorDto)
    {
        throw new NotImplementedException();
    }

    public ObjectDataset[] ReverseObjectDatasetDtoBuilder(ObjectDatasetDto[] objectDatasetsDto)
    {
        throw new NotImplementedException();
    }

    public ObjectDataset ReverseObjectDatasetDtoMapper(ObjectDatasetDto objectDatasetDto)
    {
        throw new NotImplementedException();
    }

    public ObjectDate[] ReverseObjectDateDtoBuilder(ObjectDateDto[] objectDatesDto)
    {
        throw new NotImplementedException();
    }

    public ObjectDate ReverseObjectDateDtoMapper(ObjectDateDto objectDateDto)
    {
        throw new NotImplementedException();
    }

    public ObjectDescription[] ReverseObjectDescriptionDtoBuilder(ObjectDescriptionDto[] objectDescriptionsDto)
    {
        throw new NotImplementedException();
    }

    public ObjectDescription ReverseObjectDescriptionDtoMapper(ObjectDescriptionDto objectDescriptionDto)
    {
        throw new NotImplementedException();
    }

    public ObjectIdentifier[] ReverseObjectIdentifierDtoBuilder(ObjectIdentifierDto[] objectIdentifiersDto)
    {
        throw new NotImplementedException();
    }

    public ObjectIdentifier ReverseObjectIdentifierDtoMapper(ObjectIdentifierDto objectIdentifierDto)
    {
        throw new NotImplementedException();
    }

    public ObjectInstance[] ReverseObjectInstanceDtoBuilder(ObjectInstanceDto[] objectInstancesDto)
    {
        throw new NotImplementedException();
    }

    public ObjectInstance ReverseObjectInstanceDtoMapper(ObjectInstanceDto objectInstanceDto)
    {
        throw new NotImplementedException();
    }

    public ObjectRelationship[] ReverseObjectRelationshipDtoBuilder(ObjectRelationshipDto[] objectRelationshipsDto)
    {
        throw new NotImplementedException();
    }

    public ObjectRelationship ReverseObjectRelationshipDtoMapper(ObjectRelationshipDto objectRelationshipDto)
    {
        throw new NotImplementedException();
    }

    public ObjectRight[] ReverseObjectRightDtoBuilder(ObjectRightDto[] objectRightsDto)
    {
        throw new NotImplementedException();
    }

    public ObjectRight ReverseObjectRightDtoMapper(ObjectRightDto objectRightDto)
    {
        throw new NotImplementedException();
    }

    public ObjectTitle[] ReverseObjectTitleDtoBuilder(ObjectTitleDto[] objectTitlesDto)
    {
        throw new NotImplementedException();
    }

    public ObjectTitle ReverseObjectTitleDtoMapper(ObjectTitleDto objectTitleDto)
    {
        throw new NotImplementedException();
    }

    public ObjectTopic[] ReverseObjectTopicDtoBuilder(ObjectTopicDto[] objectTopicsDto)
    {
        throw new NotImplementedException();
    }

    public ObjectTopic ReverseObjectTopicDtoMapper(ObjectTopicDto objectTopicDto)
    {
        throw new NotImplementedException();
    }
}