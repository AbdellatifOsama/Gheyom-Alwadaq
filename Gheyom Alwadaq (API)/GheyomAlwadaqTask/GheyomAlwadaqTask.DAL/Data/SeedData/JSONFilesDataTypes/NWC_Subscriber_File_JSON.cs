using GheyomAlwadaqTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.DAL.Data.SeedData.JSONFilesDataTypes
{
    internal class NWC_Subscriber_File_JSON
    {
        public int NWC_Subscriber_File_Id { get; set; }
        public string NWC_Subscriber_File_Name { get; set; }
        public string NWC_Subscriber_File_City { get; set; }
        public string NWC_Subscriber_File_Area { get; set; }
        public string NWC_Subscriber_File_Mobile { get; set; }
        public string NWC_Subscriber_File_Reasons { get; set; }
    }
}
