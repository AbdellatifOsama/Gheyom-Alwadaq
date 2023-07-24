using System.ComponentModel.DataAnnotations;

namespace GheyomAlwadaqTask.API.DTOs
{
    public class SubscriberDTO
    {
        [Range(1000_0000_00, 9999_9999_99, ErrorMessage = "The Id Must Be 10 Numeric Digits")]
        public string NWC_Subscriber_File_Id { get; set; }
        [MaxLength(100)]
        public string NWC_Subscriber_File_Name { get; set; }
        [MaxLength(50)]
        public string NWC_Subscriber_File_City { get; set; }
        [MaxLength(50)]
        public string NWC_Subscriber_File_Area { get; set; }
        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string NWC_Subscriber_File_Mobile { get; set; }
        [MaxLength(100)]
        public string? NWC_Subscriber_File_Reasons { get; set; }
    }
}
