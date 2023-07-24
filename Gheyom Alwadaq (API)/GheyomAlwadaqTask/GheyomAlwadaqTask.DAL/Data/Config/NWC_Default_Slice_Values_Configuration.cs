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
    internal class NWC_Default_Slice_Values_Configuration : IEntityTypeConfiguration<NWC_Default_Slice_Values>
    {
        public void Configure(EntityTypeBuilder<NWC_Default_Slice_Values> builder)
        {
            builder.HasKey(P => P.NWC_Default_Slice_Values_Code);
            builder.Property(P => P.NWC_Default_Slice_Values_Code).HasColumnType("char(1)");
            builder.Property(P => P.NWC_Default_Slice_Values_Name).HasColumnType("nvarchar(50)");
            builder.Property(P => P.NWC_Default_Slice_Values_Water_Price).HasColumnType("decimal(6,2)");
            builder.Property(P => P.NWC_Default_Slice_Values_Sanitation_Price).HasColumnType("decimal(6,2)");
            builder.Property(P => P.NWC_Default_Slice_Values_Reasons).HasColumnType("nvarchar(100)")
                                                                    .IsRequired(false);
        }
    }
}
