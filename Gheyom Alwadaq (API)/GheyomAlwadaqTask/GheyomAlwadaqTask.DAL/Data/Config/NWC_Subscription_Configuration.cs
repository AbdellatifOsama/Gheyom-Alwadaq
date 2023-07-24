using GheyomAlwadaqTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.DAL.Data.Config
{
    internal class NWC_Subscription_Configuration : IEntityTypeConfiguration<NWC_Subscription_File>
    {
        public void Configure(EntityTypeBuilder<NWC_Subscription_File> builder)
        {
            builder.HasKey(P => P.NWC_Subscription_File_No);
            builder.Property(P => P.NWC_Subscription_File_No).HasColumnType("char(10)");
            builder.Property(P => P.NWC_Subscription_File_Subscriber_Code).HasColumnType("char(10)");
            builder.HasOne(P => P.NWC_Subscriber_File)
                .WithMany().
                HasForeignKey(P => P.NWC_Subscription_File_Subscriber_Code);
            builder.Property(P => P.NWC_Subscription_File_Rreal_Estate_Types_Code).HasColumnType("char(1)");
            builder.HasOne(P => P.NWC_Rreal_Estate_Types)
                .WithMany()
                .HasForeignKey(P => P.NWC_Subscription_File_Rreal_Estate_Types_Code);
            builder.Property(P => P.NWC_Subscription_File_Reasons).HasColumnType("nvarchar(100)")
                                                                    .IsRequired(false);
            builder.Property(P => P.NWC_Subscription_File_Subscriber_Code).HasColumnType("char(10)");
        }
    }
}
