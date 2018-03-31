using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSecureStore.Storage
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {

        }

        public DbSet<Set> Sets { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemClaim> Claims { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RuleSet> RuleSets { get; set; }
    }

    protected override void OnModelCreating(IModelBuilder builder)
    {

    }
}
