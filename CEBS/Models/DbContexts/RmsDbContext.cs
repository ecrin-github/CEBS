using CEBS.Configs;
using CEBS.Models.Context.Rms;
using CEBS.Models.RMS;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Models.DbContexts;

public class RmsDbContext : DbContext
{
    public RmsDbContext(DbContextOptions<RmsDbContext> options, DbSet<AccessPrereqType> accessPrereqTypes,
        DbSet<CheckStatusType> checkStatusTypes, DbSet<DtpStatusType> dtpStatusTypes,
        DbSet<DupStatusType> dupStatusTypes, DbSet<LegalStatusType> legalStatusTypes,
        DbSet<RepoAccessType> repoAccessTypes, DbSet<AccessPrereq> accessPrereqs, DbSet<Dta> dtas, 
        DbSet<Dtp> dtps, DbSet<DtpDataset> dtpDatasets, DbSet<DtpObject> dtpObjects,
        DbSet<DtpStudy> dtpStudies, DbSet<Dua> duas, DbSet<Dup> dups, DbSet<DupObject> dupObjects, DbSet<DupPrereq> dupPrereqs,
        DbSet<ProcessNote> processNotes, DbSet<ProcessPeople> processPeople, DbSet<SecondaryUse> secondaryUses)
        : base(options)
    {
        AccessPrereqTypes = accessPrereqTypes ?? throw new ArgumentNullException(nameof(accessPrereqTypes));
        CheckStatusTypes = checkStatusTypes ?? throw new ArgumentNullException(nameof(checkStatusTypes));
        DtpStatusTypes = dtpStatusTypes ?? throw new ArgumentNullException(nameof(dtpStatusTypes));
        DupStatusTypes = dupStatusTypes ?? throw new ArgumentNullException(nameof(dupStatusTypes));
        LegalStatusTypes = legalStatusTypes ?? throw new ArgumentNullException(nameof(legalStatusTypes));
        RepoAccessTypes = repoAccessTypes ?? throw new ArgumentNullException(nameof(repoAccessTypes));
        
        AccessPrereqs = accessPrereqs ?? throw new ArgumentNullException(nameof(accessPrereqs));
        Dtas = dtas ?? throw new ArgumentNullException(nameof(dtas));
        Dtps = dtps ?? throw new ArgumentNullException(nameof(dtps));
        DtpDatasets = dtpDatasets ?? throw new ArgumentNullException(nameof(dtpDatasets));
        DtpObjects = dtpObjects ?? throw new ArgumentNullException(nameof(dtpObjects));
        DtpStudies = dtpStudies ?? throw new ArgumentNullException(nameof(dtpStudies));
        Duas = duas ?? throw new ArgumentNullException(nameof(duas));
        Dups = dups ?? throw new ArgumentNullException(nameof(dups));
        DupObjects = dupObjects ?? throw new ArgumentNullException(nameof(dupObjects));
        DupPrereqs = dupPrereqs ?? throw new ArgumentNullException(nameof(dupPrereqs));
        ProcessNotes = processNotes ?? throw new ArgumentNullException(nameof(processNotes));
        ProcessPeople = processPeople ?? throw new ArgumentNullException(nameof(processPeople));
        SecondaryUses = secondaryUses ?? throw new ArgumentNullException(nameof(secondaryUses));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            $"Host={DbConfigs.RmsDbConfigs.Host};Database={DbConfigs.RmsDbConfigs.Database};Username={DbConfigs.RmsDbConfigs.Username};Password={DbConfigs.RmsDbConfigs.Password}");

    public DbSet<AccessPrereqType> AccessPrereqTypes { get; set; }
    public DbSet<CheckStatusType> CheckStatusTypes { get; set; }
    public DbSet<DtpStatusType> DtpStatusTypes { get; set; }
    public DbSet<DupStatusType> DupStatusTypes { get; set; }
    public DbSet<LegalStatusType> LegalStatusTypes { get; set; }
    public DbSet<RepoAccessType> RepoAccessTypes { get; set; }
    
    
    
    public DbSet<AccessPrereq> AccessPrereqs { get; set; }
    public DbSet<Dta> Dtas { get; set; }
    public DbSet<Dtp> Dtps { get; set; }
    public DbSet<DtpDataset> DtpDatasets { get; set; }
    public DbSet<DtpObject> DtpObjects { get; set; }
    public DbSet<DtpStudy> DtpStudies { get; set; }
    public DbSet<Dua> Duas { get; set; }
    public DbSet<Dup> Dups { get; set; }
    public DbSet<DupObject> DupObjects { get; set; }
    public DbSet<DupPrereq> DupPrereqs { get; set; }
    public DbSet<ProcessNote> ProcessNotes { get; set; }
    public DbSet<ProcessPeople> ProcessPeople { get; set; }
    public DbSet<SecondaryUse> SecondaryUses { get; set; }
    
}