using Microsoft.Extensions.Logging;
using SimpleSecureStore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSecureStore.Data
{
    public class StoreContextSeed
    {
            public static async Task SeedAsync(StoreContext catalogContext,
                ILoggerFactory loggerFactory, int? retry = 0)
            {
                int retryForAvailability = retry.Value;
                try
                {
                    // TODO: Only run this if using a real database
                    // context.Database.Migrate();

                    if (!catalogContext.CatalogBrands.Any())
                    {
                        catalogContext.CatalogBrands.AddRange(
                            GetPreconfiguredSets());

                        await catalogContext.SaveChangesAsync();
                    }

                    if (!catalogContext.CatalogTypes.Any())
                    {
                        catalogContext.CatalogTypes.AddRange(
                            GetPreconfiguredCatalogTypes());

                        await catalogContext.SaveChangesAsync();
                    }

                    if (!catalogContext.CatalogItems.Any())
                    {
                        catalogContext.CatalogItems.AddRange(
                            GetPreconfiguredItems());

                        await catalogContext.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    if (retryForAvailability < 10)
                    {
                        retryForAvailability++;
                        var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                        log.LogError(ex.Message);
                        await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                    }
                }
            }

            static IEnumerable<StoreContext> GetPreconfiguredSets()
            {
                return new List<Set>()
            {
                new Set()
                {
                    Key = "users",
                    
                    Items = new Item()
                    {
                        Key = "de/myuser",
                        SetKey = "users",
                        Data = "",
                        Claims = new List<ItemClaim>
                    }
                }
            };
            }

    }
}
