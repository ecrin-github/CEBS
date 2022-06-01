using CEBS.Configs;
using CEBS.Models.MDM.Object;
using CEBS.Models.MDM.Study;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Models.DbContexts;

public class MdmDbContext : DbContext
{
    public MdmDbContext(DbContextOptions<MdmDbContext> options, DbSet<Study> studies,
        DbSet<StudyContributor> studyContributors, DbSet<StudyFeature> studyFeatures,
        DbSet<StudyIdentifier> studyIdentifiers, DbSet<StudyReference> studyReferences,
        DbSet<StudyRelationship> studyRelationships, DbSet<StudyTitle> studyTitles, DbSet<StudyTopic> studyTopics,
        DbSet<DataObject> dataObjects, DbSet<ObjectContributor> objectContributors, DbSet<ObjectDataset> objectDatasets,
        DbSet<ObjectDate> objectDates, DbSet<ObjectDescription> objectDescriptions,
        DbSet<ObjectIdentifier> objectIdentifiers, DbSet<ObjectInstance> objectInstances,
        DbSet<ObjectRelationship> objectRelationships, DbSet<ObjectRight> objectRights, DbSet<ObjectTitle> objectTitles,
        DbSet<ObjectTopic> objectTopics)
        : base(options)
    {
        Studies = studies ?? throw new ArgumentNullException(nameof(studies));
        StudyContributors = studyContributors ?? throw new ArgumentNullException(nameof(studyContributors));
        StudyFeatures = studyFeatures ?? throw new ArgumentNullException(nameof(studyFeatures));
        StudyIdentifiers = studyIdentifiers ?? throw new ArgumentNullException(nameof(studyIdentifiers));
        StudyReferences = studyReferences ?? throw new ArgumentNullException(nameof(studyReferences));
        StudyRelationships = studyRelationships ?? throw new ArgumentNullException(nameof(studyRelationships));
        StudyTitles = studyTitles ?? throw new ArgumentNullException(nameof(studyTitles));
        StudyTopics = studyTopics ?? throw new ArgumentNullException(nameof(studyTopics));
        DataObjects = dataObjects ?? throw new ArgumentNullException(nameof(dataObjects));
        ObjectContributors = objectContributors ?? throw new ArgumentNullException(nameof(objectContributors));
        ObjectDatasets = objectDatasets ?? throw new ArgumentNullException(nameof(objectDatasets));
        ObjectDates = objectDates ?? throw new ArgumentNullException(nameof(objectDates));
        ObjectDescriptions = objectDescriptions ?? throw new ArgumentNullException(nameof(objectDescriptions));
        ObjectIdentifiers = objectIdentifiers ?? throw new ArgumentNullException(nameof(objectIdentifiers));
        ObjectInstances = objectInstances ?? throw new ArgumentNullException(nameof(objectInstances));
        ObjectRelationships = objectRelationships ?? throw new ArgumentNullException(nameof(objectRelationships));
        ObjectRights = objectRights ?? throw new ArgumentNullException(nameof(objectRights));
        ObjectTitles = objectTitles ?? throw new ArgumentNullException(nameof(objectTitles));
        ObjectTopics = objectTopics ?? throw new ArgumentNullException(nameof(objectTopics));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            $"Host={DbConfigs.MdmDbConfigs.Host};Database={DbConfigs.MdmDbConfigs.Database};Username={DbConfigs.MdmDbConfigs.Username};Password={DbConfigs.MdmDbConfigs.Password}");


    // Study tables
    public DbSet<Study> Studies { get; set; }
    public DbSet<StudyContributor> StudyContributors { get; set; }
    public DbSet<StudyFeature> StudyFeatures { get; set; }
    public DbSet<StudyIdentifier> StudyIdentifiers { get; set; }
    public DbSet<StudyReference> StudyReferences { get; set; }
    public DbSet<StudyRelationship> StudyRelationships { get; set; }
    public DbSet<StudyTitle> StudyTitles { get; set; }
    public DbSet<StudyTopic> StudyTopics { get; set; }

    // Data object tables
    public DbSet<DataObject> DataObjects { get; set; }
    public DbSet<ObjectContributor> ObjectContributors { get; set; }
    public DbSet<ObjectDataset> ObjectDatasets { get; set; }
    public DbSet<ObjectDate> ObjectDates { get; set; }
    public DbSet<ObjectDescription> ObjectDescriptions { get; set; }
    public DbSet<ObjectIdentifier> ObjectIdentifiers { get; set; }
    public DbSet<ObjectInstance> ObjectInstances { get; set; }
    public DbSet<ObjectRelationship> ObjectRelationships { get; set; }
    public DbSet<ObjectRight> ObjectRights { get; set; }
    public DbSet<ObjectTitle> ObjectTitles { get; set; }
    public DbSet<ObjectTopic> ObjectTopics { get; set; }
}