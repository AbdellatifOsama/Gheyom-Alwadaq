using GheyomAlwadaqTask.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace GheyomAlwadaqTask.API.DTOs
{
    public class FlatSubscribtionDTO
    {
        public string NWC_Subscription_File_No { get; set; }
        [Range(0, 99)]
        public int NWC_Subscription_File_Unit_No { get; set; }
        public bool NWC_Subscription_File_Is_There_Sanitation { get; set; }
        [Range(0, 9999_9999_99)]
        public int NWC_Subscription_File_Last_Reading_Meter { get; set; }
        public string NWC_Subscription_File_Reasons { get; set; }
        public string NWC_Subscriber_File_Id { get; set; }
        public string NWC_Subscriber_File_Name { get; set; }
        public char NWC_Rreal_Estate_Types_Code { get; set; }
        public string NWC_Rreal_Estate_Types_Name { get; set; }
        public string nwC_Subscriber_File_Mobile { get; set; }
    }
}
