using CallScheduler.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CallScheduler.Data
{
    public class CallSchedulerDbContext : IdentityDbContext<CustomUser, CustomRole, string>
    {
        public CallSchedulerDbContext(DbContextOptions<CallSchedulerDbContext> options)
            : base(options)
        {
        }

        #region Tables
        public DbSet<Initiator> Initiators { get; set; }
        public DbSet<Assigner> Assigners { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAdmin> BankAdmins { get; set; }
        public DbSet<InitiatedCall> InitiatedCalls { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<CallTimeline> CallTimelines { get; set; }
        public DbSet<TeamLead> TeamLeads { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineVariant> MachineVariants { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("callscheduler");

            builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .ToList()
                .ForEach(p => p.Relational().ColumnName = p.Name.ToLower());
            builder.Model.GetEntityTypes()
                .ToList()
                .ForEach(e => e.Relational().TableName = e.Relational().TableName.ToLower());

            builder.Entity<CustomUser>().ToTable("users")
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CustomUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CustomUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CustomRole>().ToTable("roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("userroles");
            builder.Entity<IdentityUserToken<string>>().ToTable("tokens");
            builder.Entity<IdentityUserClaim<string>>().ToTable("userclaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("userlogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("roleclaims");

            builder.Entity<Call>()
               .HasOne(s => s.Assigner)
               .WithMany(g => g.Calls)
               .HasForeignKey(s => s.AssignerId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Call>()
               .HasOne(s => s.Initiator)
               .WithMany(g => g.Calls)
               .HasForeignKey(s => s.InitiatorId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Call>()
               .HasOne(s => s.Engineer)
               .WithMany(g => g.Calls)
               .HasForeignKey(s => s.EngineerId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Initiator>()
               .HasOne(s => s.Bank)
               .WithMany(g => g.Initiators)
               .HasForeignKey(s => s.BankId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Call>()
               .HasOne(s => s.Bank)
               .WithMany(g => g.Calls)
               .HasForeignKey(s => s.BankId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Call>()
               .HasOne(s => s.Machine)
               .WithMany(g => g.Calls)
               .HasForeignKey(s => s.MachineId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Machine>()
               .HasOne(s => s.Bank)
               .WithMany(g => g.Machines)
               .HasForeignKey(s => s.BankId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Machine>()
               .HasOne(s => s.MachineVariant)
               .WithMany(g => g.Machines)
               .HasForeignKey(s => s.MachineVariantId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Part>()
               .HasOne(s => s.MachineVariant)
               .WithMany(g => g.Parts)
               .HasForeignKey(s => s.MachineVariantId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CallTimeline>()
               .HasOne(s => s.Call)
               .WithMany(g => g.CallTimelines)
               .HasForeignKey(s => s.CallId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<InitiatedCall>()
               .HasOne(s => s.Machine)
               .WithMany(g => g.InitiatedCalls)
               .HasForeignKey(s => s.MachineId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<InitiatedCall>()
               .HasOne(s => s.Initiator)
               .WithMany(g => g.InitiatedCalls)
               .HasForeignKey(s => s.InitiatorId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<InitiatedCall>()
               .HasOne(s => s.Bank)
               .WithMany(g => g.InitiatedCalls)
               .HasForeignKey(s => s.BankId)
               .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<CallScheduler.Models.Incident> Incident { get; set; }

        public DbSet<CallScheduler.Models.Record> Record { get; set; }

        public DbSet<CallScheduler.Models.Care> Care { get; set; }
    }
}
