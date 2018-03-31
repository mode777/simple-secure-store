using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSecureStore.Storage
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {

        }

        public DbSet<Set> Sets { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemClaim> Claims { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RuleSet> RuleSets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Set>(e => 
            {
                e.ToTable("sets");
                e.HasKey(x => x.Key);
                e.Property(x => x.Key).IsRequired();
                e.HasMany(x => x.Items)
                    .WithOne()
                    .HasForeignKey(x => x.SetKey)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasMany(x => x.RuleSets)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Item>(e => 
            {
                e.ToTable("items");
                e.HasKey(x => new { x.Key, x.SetKey });
                e.HasMany(x => x.Claims)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ItemClaim>(e => 
            {
                e.ToTable("item_claims");
                e.HasKey(x => x.Id);
                e.Property(x => x.ClaimType).IsRequired();
            });

            builder.Entity<Rule>(e =>
            {
                e.ToTable("rules");
                e.HasKey(x => x.Id);
                e.Property(x => x.ClaimType).IsRequired();
            });

            builder.Entity<RuleSet>(e => 
            {
                e.ToTable("rule_set");
                e.HasKey(x => x.Id);
                e.HasMany(x => x.Rules)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
