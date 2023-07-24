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
    internal class NWC_Subscriber_Configuration : IEntityTypeConfiguration<NWC_Subscriber_File>
    {
        public void Configure(EntityTypeBuilder<NWC_Subscriber_File> builder)
        {
            builder.HasKey(K => K.NWC_Subscriber_File_Id);
            builder.Property(P => P.NWC_Subscriber_File_Id).HasColumnType("char(10)")
                                                            .IsRequired();
            builder.Property(P =>P.NWC_Subscriber_File_Name).HasColumnType("nvarchar(100)")
                                                            .IsRequired();
            builder.Property(P => P.NWC_Subscriber_File_City).HasColumnType("nvarchar(50)")
                                                            .IsRequired();
            builder.Property(P =>P.NWC_Subscriber_File_Area).HasColumnType("nvarchar(50)")
                                                            .IsRequired();
            builder.Property(P => P.NWC_Subscriber_File_Mobile).HasColumnType("nvarchar(20)")
                                                                .IsRequired();
            builder.Property(P => P.NWC_Subscriber_File_Reasons).HasColumnType("nvarchar(100)")
                                                                .IsRequired(false);
        }
    }
}
