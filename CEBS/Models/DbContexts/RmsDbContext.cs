using CEBS.Configs;
using CEBS.Models.Context.Rms;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Models.DbContexts;

public class RmsDbContext : DbContext
{
    public RmsDbContext(DbContextOptions<RmsDbContext> options, DbSet<AccessPrereqType> accessPrereqTypes,
        DbSet<CheckStatusType> checkStatusTypes, DbSet<DtpStatusType> dtpStatusTypes,
        DbSet<DupStatusType> dupStatusTypes, DbSet<LegalStatusType> legalStatusTypes,
        DbSet<RepoAccessType> repoAccessTypes)
        : base(options)
    {
        AccessPrereqTypes = accessPrereqTypes ?? throw new ArgumentNullException(nameof(accessPrereqTypes));
        CheckStatusTypes = checkStatusTypes ?? throw new ArgumentNullException(nameof(checkStatusTypes));
        DtpStatusTypes = dtpStatusTypes ?? throw new ArgumentNullException(nameof(dtpStatusTypes));
        DupStatusTypes = dupStatusTypes ?? throw new ArgumentNullException(nameof(dupStatusTypes));
        LegalStatusTypes = legalStatusTypes ?? throw new ArgumentNullException(nameof(legalStatusTypes));
        RepoAccessTypes = repoAccessTypes ?? throw new ArgumentNullException(nameof(repoAccessTypes));
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
}