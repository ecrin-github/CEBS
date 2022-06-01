using CEBS.Configs;
using CEBS.Models.Audit;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Models.DbContexts;

public class AuditDbContext : DbContext
{
    public AuditDbContext(DbContextOptions<AuditDbContext> options, 
        DbSet<RmsRecordChange> rmsRecordChanges,
        DbSet<MdrRecordChange> mdrRecordChanges) 
        : base(options)
    {
        RmsRecordChanges = rmsRecordChanges ?? throw new ArgumentNullException(nameof(rmsRecordChanges));
        MdrRecordChanges = mdrRecordChanges ?? throw new ArgumentNullException(nameof(mdrRecordChanges));
    }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql($"Host={DbConfigs.AuditDbConfigs.Host};Database={DbConfigs.AuditDbConfigs.Database};Username={DbConfigs.AuditDbConfigs.Username};Password={DbConfigs.AuditDbConfigs.Password}");

    // Audit
    public DbSet<RmsRecordChange> RmsRecordChanges {get; set;}
    public DbSet<MdrRecordChange> MdrRecordChanges  {get; set;}
}