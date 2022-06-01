using CEBS.Configs;
using Microsoft.EntityFrameworkCore;

namespace CEBS.Models.DbContexts;

public class UserDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            $"Host={DbConfigs.UserDbConfigs.Host};Database={DbConfigs.UserDbConfigs.Database};Username={DbConfigs.UserDbConfigs.Username};Password={DbConfigs.UserDbConfigs.Password}");

}