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
    internal class NWC_Invoices_Configuration : IEntityTypeConfiguration<NWC_Invoices>
    {
        public void Configure(EntityTypeBuilder<NWC_Invoices> builder)
        {
            builder.HasKey(P => P.NWC_Invoices_No);
            builder.Property(P => P.NWC_Invoices_No).HasColumnType("char(10)");
            builder.Property(P => P.NWC_Invoices_Year).HasColumnType("char(2)");
            builder.Property(P => P.NWC_Invoices_Year).HasColumnType("char(2)");
            builder.Property(P => P.NWC_Invoices_Rreal_Estate_Types).HasColumnType("char(1)");
            builder.HasOne(P => P.NWC_Rreal_Estate_Types)
                .WithMany().
                HasForeignKey(P => P.NWC_Invoices_Rreal_Estate_Types);
            //Invoices Subscribtion configuration 
            builder.Property(P => P.NWC_Invoices_Subscription_No).HasColumnType("char(10)");
            builder.HasOne(P => P.NWC_Subscription_File)
                .WithMany()
                .HasForeignKey(P => P.NWC_Invoices_Subscription_No)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //Invoices Subscriber configuration 
            builder.Property(P => P.NWC_Invoices_Subscriber_No).HasColumnType("char(10)");
            builder.HasOne(P => P.NWC_Subscriber_File)
                .WithMany().
                HasForeignKey(P => P.NWC_Invoices_Subscriber_No);
            //Entity Date Attributes
            builder.Property(P => P.NWC_Invoices_Date).HasColumnType("date");
            builder.Property(P => P.NWC_Invoices_From).HasColumnType("date");
            builder.Property(P => P.NWC_Invoices_To).HasColumnType("date");
            //Entity Consumptions Attributes
            builder.Property(P => P.NWC_Invoices_Previous_Consumption_Amount).HasColumnType("int");
            builder.Property(P => P.NWC_Invoices_Current_Consumption_Amount).HasColumnType("int");
            builder.Property(P => P.NWC_Invoices_Amount_Consumption).HasColumnType("int");
            //Entity Attributes Configuration
            builder.Property(P => P.NWC_Invoices_Service_Fee).HasColumnType("dec(10,2)");
            builder.Property(P => P.NWC_Invoices_Tax_Rate).HasColumnType("dec(10,2)");
            builder.Property(P => P.NWC_Invoices_Is_There_Sanitation).HasColumnType("varchar(6)");
            builder.Property(P => P.NWC_Invoices_Consumption_Value).HasColumnType("dec(10,2)");
            builder.Property(P => P.NWC_Invoices_Wastewater_Consumption_Value).HasColumnType("dec(10,2)");
            builder.Property(P => P.NWC_Invoices_Total_Invoice).HasColumnType("dec(10,2)");
            builder.Property(P => P.NWC_Invoices_Tax_Value).HasColumnType("dec(10,2)");
            builder.Property(P => P.NWC_Invoices_Total_Bill).HasColumnType("dec(10,2)");
            builder.Property(P => P.NWC_Invoices_Total_Reasons).HasColumnType("varchar(100)");
        }
    }
}
