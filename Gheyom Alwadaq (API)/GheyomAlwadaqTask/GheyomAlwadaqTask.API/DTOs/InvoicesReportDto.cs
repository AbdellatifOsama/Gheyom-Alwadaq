namespace GheyomAlwadaqTask.API.DTOs
{
    public class InvoicesReportDto
    {
        public string NWC_Invoices_No { get; set; }
        public string NWC_Invoices_Subscription_No { get; set; }
        public string NWC_Invoices_Subscriber_No { get; set; }
        public string NWC_Invoices_Subscriber_Name { get; set; }
        public string NWC_Invoices_Date { get; set; }
        public int NWC_Invoices_Previous_Consumption_Amount { get; set; }
        public int NWC_Invoices_Current_Consumption_Amount { get; set; }
        public int NWC_Invoices_Amount_Consumption { get; set; }
        public decimal NWC_Invoices_Total_Invoice { get; set; }
        public decimal NWC_Invoices_Total_Bill { get; set; }
    }
}
