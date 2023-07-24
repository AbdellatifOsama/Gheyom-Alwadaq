using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.DAL.Entities
{
    public class NWC_Invoices
    {
        public string NWC_Invoices_No { get; set; }
        public string NWC_Invoices_Year { get; set; }
        public char NWC_Invoices_Rreal_Estate_Types { get; set; }
        public string NWC_Invoices_Subscription_No { get; set; }
        public string NWC_Invoices_Subscriber_No { get; set; }
        public DateTime NWC_Invoices_Date { get; set; }
        public DateTime NWC_Invoices_From { get; set; }
        public DateTime NWC_Invoices_To { get; set; }
        public int NWC_Invoices_Previous_Consumption_Amount { get; set; }
        public int NWC_Invoices_Current_Consumption_Amount { get; set; }
        public int NWC_Invoices_Amount_Consumption { get; set; }
        public decimal NWC_Invoices_Service_Fee { get; set; }
        public decimal NWC_Invoices_Tax_Rate { get; set; }
        public string NWC_Invoices_Is_There_Sanitation { get; set; }
        public decimal NWC_Invoices_Consumption_Value { get; set; }
        public decimal NWC_Invoices_Wastewater_Consumption_Value { get; set; }
        public decimal NWC_Invoices_Total_Invoice { get; set; }
        public decimal NWC_Invoices_Tax_Value { get; set; }
        public decimal NWC_Invoices_Total_Bill { get; set; }
        public string? NWC_Invoices_Total_Reasons { get; set; }
        public NWC_Rreal_Estate_Types NWC_Rreal_Estate_Types { get; set; } // Navigational Property
        public NWC_Subscription_File NWC_Subscription_File { get; set; } // Navigational Property
        public NWC_Subscriber_File NWC_Subscriber_File { get; set; } // Navigational Property
    }
}
