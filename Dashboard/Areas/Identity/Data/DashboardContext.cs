using Dashboard.Areas.Identity.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data;

public class DashboardContext : IdentityDbContext<DashboardUser>
{
    public DashboardContext(DbContextOptions<DashboardContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {   
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        
        builder.Entity<DashboardUser>(typeBuilder =>
        {
            typeBuilder.HasMany(user => user.Sessions)
                .WithOne(session => session.User)
                .HasForeignKey(session => session.DashboardUserId)
                .IsRequired();
        });

        builder.Entity<DashboardUser>()
            .Navigation(e => e.Sessions)
            .AutoInclude();

        builder.Entity<OAuthSession>(typeBuilder =>
        {
            typeBuilder.HasOne(sessions => sessions.User)
                .WithMany(user => user.Sessions)
                .HasForeignKey(session => session.DashboardUserId)
                .IsRequired();
        });

    }

   
}
