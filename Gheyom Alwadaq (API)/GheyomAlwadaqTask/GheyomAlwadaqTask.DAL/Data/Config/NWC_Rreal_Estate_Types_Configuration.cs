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
    internal class NWC_Rreal_Estate_Types_Configuration : IEntityTypeConfiguration<NWC_Rreal_Estate_Types>
    {
        public void Configure(EntityTypeBuilder<NWC_Rreal_Estate_Types> builder)
        {
            builder.HasKey(P => P.NWC_Rreal_Estate_Types_Code);
            builder.Property(P => P.NWC_Rreal_Estate_Types_Code).HasColumnType("char(1)");
            builder.Property(P => P.NWC_Rreal_Estate_Types_Name).HasColumnType("nvarchar(15)");
            builder.Property(P => P.NWC_Rreal_Estate_Types_Reasons).HasColumnType("nvarchar(100)")
                                                                    .IsRequired(false);
        }
    }
}
