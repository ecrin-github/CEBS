using CEBS.Configs;
using CEBS.Models.Context.Ctx;
using CEBS.Models.Context.Lup;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Models.DbContexts;

public class ContextDbContext : DbContext
{
    public ContextDbContext(DbContextOptions<ContextDbContext> options,
        DbSet<CompositeHashType> compositeHashTypes, DbSet<ContributionType> contributionTypes,
        DbSet<DatasetConsentType> datasetConsentTypes,
        DbSet<DatasetDeidentificationLevel> datasetDeidentificationLevels,
        DbSet<DatasetRecordkeyType> datasetRecordkeyTypes, DbSet<DateType> dateTypes,
        DbSet<DescriptionType> descriptionTypes, DbSet<DoiStatusType> doiStatusTypes,
        DbSet<GenderEligibilityType> genderEligibilityTypes, DbSet<GeogEntityType> geogEntityTypes,
        DbSet<IdentifierType> identifierTypes, DbSet<LanguageCode> languageCodes,
        DbSet<LanguageUsageType> languageUsageTypes, DbSet<LinkType> linkTypes,
        DbSet<ObjectAccessType> objectAccessTypes, DbSet<ObjectClass> objectClasses,
        DbSet<ObjectFilterType> objectFilterTypes, DbSet<ObjectInstanceType> objectInstanceTypes,
        DbSet<ObjectRelationshipType> objectRelationshipTypes, DbSet<ObjectType> objectTypes,
        DbSet<OrgAttributeDatatype> orgAttributeDatatypes, DbSet<OrgAttributeType> orgAttributeTypes,
        DbSet<OrgClass> orgClasses, DbSet<OrgLinkType> orgLinkTypes, DbSet<OrgNameQualifierType> orgNameQualifierTypes,
        DbSet<OrgRelationshipType> orgRelationshipTypes, DbSet<OrgType> orgTypes, DbSet<ResourceType> resourceTypes,
        DbSet<RmsUserType> rmsUserTypes, DbSet<RoleClass> roleClasses, DbSet<RoleType> roleTypes,
        DbSet<SizeUnit> sizeUnits, DbSet<StudyFeatureCategory> studyFeatureCategories,
        DbSet<StudyFeatureType> studyFeatureTypes, DbSet<StudyRelationshipType> studyRelationshipTypes,
        DbSet<StudyStatus> studyStatuses, DbSet<StudyType> studyTypes, DbSet<TimeUnit> timeUnits,
        DbSet<TitleType> titleTypes, DbSet<TopicType> topicTypes, DbSet<TopicVocabulary> topicVocabularies,
        DbSet<GeogEntity> geogEntities, DbSet<MeshLookup> meshLookups, DbSet<Organisation> organisations,
        DbSet<OrgAttribute> orgAttributes, DbSet<OrgLink> orgLinks, DbSet<OrgLocation> orgLocations,
        DbSet<OrgName> orgNames, DbSet<OrgRelationship> orgRelationships, DbSet<OrgTypeMembership> orgTypeMemberships,
        DbSet<People> people, DbSet<PeopleLink> peopleLinks, DbSet<PeopleRole> peopleRoles,
        DbSet<PublishedJournal> publishedJournals, DbSet<ToMatchOrg> toMatchOrgs, DbSet<ToMatchTopic> toMatchTopics)
        : base(options)
    {
        CompositeHashTypes = compositeHashTypes ?? throw new ArgumentNullException(nameof(compositeHashTypes));
        ContributionTypes = contributionTypes ?? throw new ArgumentNullException(nameof(contributionTypes));
        DatasetConsentTypes = datasetConsentTypes ?? throw new ArgumentNullException(nameof(datasetConsentTypes));
        DatasetDeidentificationLevels = datasetDeidentificationLevels ?? throw new ArgumentNullException(nameof(datasetDeidentificationLevels));
        DatasetRecordkeyTypes = datasetRecordkeyTypes ?? throw new ArgumentNullException(nameof(datasetRecordkeyTypes));
        DateTypes = dateTypes ?? throw new ArgumentNullException(nameof(dateTypes));
        DescriptionTypes = descriptionTypes ?? throw new ArgumentNullException(nameof(descriptionTypes));
        DoiStatusTypes = doiStatusTypes ?? throw new ArgumentNullException(nameof(doiStatusTypes));
        GenderEligibilityTypes = genderEligibilityTypes ?? throw new ArgumentNullException(nameof(genderEligibilityTypes));
        GeogEntityTypes = geogEntityTypes ?? throw new ArgumentNullException(nameof(geogEntityTypes));
        IdentifierTypes = identifierTypes ?? throw new ArgumentNullException(nameof(identifierTypes));
        LanguageCodes = languageCodes ?? throw new ArgumentNullException(nameof(languageCodes));
        LanguageUsageTypes = languageUsageTypes ?? throw new ArgumentNullException(nameof(languageUsageTypes));
        LinkTypes = linkTypes ?? throw new ArgumentNullException(nameof(linkTypes));
        ObjectAccessTypes = objectAccessTypes ?? throw new ArgumentNullException(nameof(objectAccessTypes));
        ObjectClasses = objectClasses ?? throw new ArgumentNullException(nameof(objectClasses));
        ObjectFilterTypes = objectFilterTypes ?? throw new ArgumentNullException(nameof(objectFilterTypes));
        ObjectInstanceTypes = objectInstanceTypes ?? throw new ArgumentNullException(nameof(objectInstanceTypes));
        ObjectRelationshipTypes = objectRelationshipTypes ?? throw new ArgumentNullException(nameof(objectRelationshipTypes));
        ObjectTypes = objectTypes ?? throw new ArgumentNullException(nameof(objectTypes));
        OrgAttributeDatatypes = orgAttributeDatatypes ?? throw new ArgumentNullException(nameof(orgAttributeDatatypes));
        OrgAttributeTypes = orgAttributeTypes ?? throw new ArgumentNullException(nameof(orgAttributeTypes));
        OrgClasses = orgClasses ?? throw new ArgumentNullException(nameof(orgClasses));
        OrgLinkTypes = orgLinkTypes ?? throw new ArgumentNullException(nameof(orgLinkTypes));
        OrgNameQualifierTypes = orgNameQualifierTypes ?? throw new ArgumentNullException(nameof(orgNameQualifierTypes));
        OrgRelationshipTypes = orgRelationshipTypes ?? throw new ArgumentNullException(nameof(orgRelationshipTypes));
        OrgTypes = orgTypes ?? throw new ArgumentNullException(nameof(orgTypes));
        ResourceTypes = resourceTypes ?? throw new ArgumentNullException(nameof(resourceTypes));
        RmsUserTypes = rmsUserTypes ?? throw new ArgumentNullException(nameof(rmsUserTypes));
        RoleClasses = roleClasses ?? throw new ArgumentNullException(nameof(roleClasses));
        RoleTypes = roleTypes ?? throw new ArgumentNullException(nameof(roleTypes));
        SizeUnits = sizeUnits ?? throw new ArgumentNullException(nameof(sizeUnits));
        StudyFeatureCategories = studyFeatureCategories ?? throw new ArgumentNullException(nameof(studyFeatureCategories));
        StudyFeatureTypes = studyFeatureTypes ?? throw new ArgumentNullException(nameof(studyFeatureTypes));
        StudyRelationshipTypes = studyRelationshipTypes ?? throw new ArgumentNullException(nameof(studyRelationshipTypes));
        StudyStatuses = studyStatuses ?? throw new ArgumentNullException(nameof(studyStatuses));
        StudyTypes = studyTypes ?? throw new ArgumentNullException(nameof(studyTypes));
        TimeUnits = timeUnits ?? throw new ArgumentNullException(nameof(timeUnits));
        TitleTypes = titleTypes ?? throw new ArgumentNullException(nameof(titleTypes));
        TopicTypes = topicTypes ?? throw new ArgumentNullException(nameof(topicTypes));
        TopicVocabularies = topicVocabularies ?? throw new ArgumentNullException(nameof(topicVocabularies));
        GeogEntities = geogEntities ?? throw new ArgumentNullException(nameof(geogEntities));
        MeshLookups = meshLookups ?? throw new ArgumentNullException(nameof(meshLookups));
        Organisations = organisations ?? throw new ArgumentNullException(nameof(organisations));
        OrgAttributes = orgAttributes ?? throw new ArgumentNullException(nameof(orgAttributes));
        OrgLinks = orgLinks ?? throw new ArgumentNullException(nameof(orgLinks));
        OrgLocations = orgLocations ?? throw new ArgumentNullException(nameof(orgLocations));
        OrgNames = orgNames ?? throw new ArgumentNullException(nameof(orgNames));
        OrgRelationships = orgRelationships ?? throw new ArgumentNullException(nameof(orgRelationships));
        OrgTypeMemberships = orgTypeMemberships ?? throw new ArgumentNullException(nameof(orgTypeMemberships));
        People = people ?? throw new ArgumentNullException(nameof(people));
        PeopleLinks = peopleLinks ?? throw new ArgumentNullException(nameof(peopleLinks));
        PeopleRoles = peopleRoles ?? throw new ArgumentNullException(nameof(peopleRoles));
        PublishedJournals = publishedJournals ?? throw new ArgumentNullException(nameof(publishedJournals));
        ToMatchOrgs = toMatchOrgs ?? throw new ArgumentNullException(nameof(toMatchOrgs));
        ToMatchTopics = toMatchTopics ?? throw new ArgumentNullException(nameof(toMatchTopics));
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            $"Host={DbConfigs.ContextDbConfigs.Host};Database={DbConfigs.ContextDbConfigs.Database};Username={DbConfigs.ContextDbConfigs.Username};Password={DbConfigs.ContextDbConfigs.Password}");


    // Lup tables
    public DbSet<CompositeHashType> CompositeHashTypes { get; set; }
    public DbSet<ContributionType> ContributionTypes { get; set; }
    public DbSet<DatasetConsentType> DatasetConsentTypes { get; set; }
    public DbSet<DatasetDeidentificationLevel> DatasetDeidentificationLevels { get; set; }
    public DbSet<DatasetRecordkeyType> DatasetRecordkeyTypes { get; set; }
    public DbSet<DateType> DateTypes { get; set; }
    public DbSet<DescriptionType> DescriptionTypes { get; set; }
    public DbSet<DoiStatusType> DoiStatusTypes { get; set; }
    public DbSet<GenderEligibilityType> GenderEligibilityTypes { get; set; }
    public DbSet<GeogEntityType> GeogEntityTypes { get; set; }
    public DbSet<IdentifierType> IdentifierTypes { get; set; }
    public DbSet<LanguageCode> LanguageCodes { get; set; }
    public DbSet<LanguageUsageType> LanguageUsageTypes { get; set; }
    public DbSet<LinkType> LinkTypes { get; set; }
    public DbSet<ObjectAccessType> ObjectAccessTypes { get; set; }
    public DbSet<ObjectClass> ObjectClasses { get; set; }
    public DbSet<ObjectFilterType> ObjectFilterTypes { get; set; }
    public DbSet<ObjectInstanceType> ObjectInstanceTypes { get; set; }
    public DbSet<ObjectRelationshipType> ObjectRelationshipTypes { get; set; }
    public DbSet<ObjectType> ObjectTypes { get; set; }

    public DbSet<OrgAttributeDatatype> OrgAttributeDatatypes { get; set; }
    public DbSet<OrgAttributeType> OrgAttributeTypes { get; set; }
    public DbSet<OrgClass> OrgClasses { get; set; }
    public DbSet<OrgLinkType> OrgLinkTypes { get; set; }
    public DbSet<OrgNameQualifierType> OrgNameQualifierTypes { get; set; }
    public DbSet<OrgRelationshipType> OrgRelationshipTypes { get; set; }
    public DbSet<OrgType> OrgTypes { get; set; }
    public DbSet<ResourceType> ResourceTypes { get; set; }
    public DbSet<RmsUserType> RmsUserTypes { get; set; }
    public DbSet<RoleClass> RoleClasses { get; set; }
    public DbSet<RoleType> RoleTypes { get; set; }
    public DbSet<SizeUnit> SizeUnits { get; set; }
    public DbSet<StudyFeatureCategory> StudyFeatureCategories { get; set; }
    public DbSet<StudyFeatureType> StudyFeatureTypes { get; set; }
    public DbSet<StudyRelationshipType> StudyRelationshipTypes { get; set; }
    public DbSet<StudyStatus> StudyStatuses { get; set; }
    public DbSet<StudyType> StudyTypes { get; set; }
    public DbSet<TimeUnit> TimeUnits { get; set; }
    public DbSet<TitleType> TitleTypes { get; set; }
    public DbSet<TopicType> TopicTypes { get; set; }
    public DbSet<TopicVocabulary> TopicVocabularies { get; set; }


    // Ctx tables
    public DbSet<GeogEntity> GeogEntities { get; set; }
    public DbSet<MeshLookup> MeshLookups { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<OrgAttribute> OrgAttributes { get; set; }
    public DbSet<OrgLink> OrgLinks { get; set; }
    public DbSet<OrgLocation> OrgLocations { get; set; }
    public DbSet<OrgName> OrgNames { get; set; }
    public DbSet<OrgRelationship> OrgRelationships { get; set; }
    public DbSet<OrgTypeMembership> OrgTypeMemberships { get; set; }
    public DbSet<People> People { get; set; }
    public DbSet<PeopleLink> PeopleLinks { get; set; }
    public DbSet<PeopleRole> PeopleRoles { get; set; }
    public DbSet<PublishedJournal> PublishedJournals { get; set; }
    public DbSet<ToMatchOrg> ToMatchOrgs { get; set; }
    public DbSet<ToMatchTopic> ToMatchTopics { get; set; }
}