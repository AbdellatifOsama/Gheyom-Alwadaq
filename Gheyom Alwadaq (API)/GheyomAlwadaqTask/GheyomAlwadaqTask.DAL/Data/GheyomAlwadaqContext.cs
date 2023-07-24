using GheyomAlwadaqTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.DAL.Data
{
    public class GheyomAlwadaqContext:DbContext
    {
        public GheyomAlwadaqContext(DbContextOptions<GheyomAlwadaqContext> context):base(context)
        {
            
        }
        DbSet<NWC_Subscriber_File> NWC_Subscriber_File { get; set; }
        DbSet<NWC_Subscription_File> NWC_Subscription_File { get; set; }
        DbSet<NWC_Default_Slice_Values> NWC_Default_Slice_Values { get; set; }
        DbSet<NWC_Rreal_Estate_Types> NWC_Rreal_Estate_Types { get; set; }
        DbSet<NWC_Invoices> NWC_Invoices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
