﻿using GheyomAlwadaqTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.DAL.Data.SeedData.JSONFilesDataTypes
{
    internal class NWC_Subscription_File_JSON
    {
        public string NWC_Subscription_File_No { get; set; }
        public int NWC_Subscription_File_Subscriber_Code { get; set; }
        public int NWC_Subscription_File_Rreal_Estate_Types_Code { get; set; }
        [Range(0, 99)]
        public int NWC_Subscription_File_Unit_No { get; set; }
        public bool NWC_Subscription_File_Is_There_Sanitation { get; set; }
        [Range(0, 9999_9999_99)]
        public int NWC_Subscription_File_Last_Reading_Meter { get; set; }
        public string NWC_Subscription_File_Reasons { get; set; }
    }
}
