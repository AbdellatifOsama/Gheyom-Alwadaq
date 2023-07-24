using GheyomAlwadaqTask.DAL.Data.SeedData.JSONFilesDataTypes;
using GheyomAlwadaqTask.DAL.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GheyomAlwadaqTask.DAL.Data
{
    public class DataInitialization
    {
        private static readonly string FolderPath = "../GheyomAlwadaqTask.DAL/Data/SeedData/JSON Files/";
        public async static Task Data_Initialize_Async(GheyomAlwadaqContext AlwadaqContext, ILoggerFactory loggerFactory)
        {
            await NWC_Default_Slice_Values_Data_Initialize_Async(AlwadaqContext, loggerFactory);
            await NWC_Subscribers_File_Data_Initialize_Async(AlwadaqContext, loggerFactory);
            await NWC_Rreal_Estate_Types_Data_Initialize_Async(AlwadaqContext, loggerFactory);
            await NWC_Subscription_File_Data_Initialize_Async(AlwadaqContext, loggerFactory);
            await NWC_Invoices_Data_Initialize_Async(AlwadaqContext, loggerFactory);
        }
        private async static Task NWC_Default_Slice_Values_Data_Initialize_Async(GheyomAlwadaqContext AlwadaqContext, ILoggerFactory loggerFactory)
        {
            try
            {
                var FileName = "NWC_Default_Slice_Values_Data.json";
                var FilePath = Path.Combine(FolderPath, FileName);
                if (!AlwadaqContext.Set<NWC_Default_Slice_Values>().Any())
                {
                    var JsonData = await File.ReadAllTextAsync(FilePath);
                    var DataObjects = JsonSerializer.Deserialize<List<NWC_Default_Slice_Values_JSON>>(JsonData);
                    var MappedObjects = Default_Slice_Values_DataTypesEditor(DataObjects);
                    foreach (var obj in MappedObjects)
                    {
                        AlwadaqContext.Set<NWC_Default_Slice_Values>().Add(obj);
                        await AlwadaqContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataInitialization>();
                logger.LogError(ex.Message);
            }
        }
        private static List<NWC_Default_Slice_Values> Default_Slice_Values_DataTypesEditor(List<NWC_Default_Slice_Values_JSON> default_Slice_Values_JSONs)
        {
            List<NWC_Default_Slice_Values> _Default_Slice_Values = new List<NWC_Default_Slice_Values>();
            foreach (var item in default_Slice_Values_JSONs)
            {
                NWC_Default_Slice_Values slice = new NWC_Default_Slice_Values()
                {
                    NWC_Default_Slice_Values_Code = char.Parse(item.NWC_Default_Slice_Values_Code.ToString()),
                    NWC_Default_Slice_Values_Name = item.NWC_Default_Slice_Values_Name,
                    NWC_Default_Slice_Values_Condtion = item.NWC_Default_Slice_Values_Condtion,
                    NWC_Default_Slice_Values_Water_Price = (decimal)item.NWC_Default_Slice_Values_Water_Price,
                    NWC_Default_Slice_Values_Sanitation_Price = (decimal)item.NWC_Default_Slice_Values_Sanitation_Price,
                    NWC_Default_Slice_Values_Reasons = item.NWC_Default_Slice_Values_Reasons
                };
                _Default_Slice_Values.Add(slice);
            }
            return _Default_Slice_Values;
        }

        private async static Task NWC_Subscribers_File_Data_Initialize_Async(GheyomAlwadaqContext AlwadaqContext, ILoggerFactory loggerFactory)
        {
            try
            {
                var FileName = "NWC_Subscribers_Data.json";
                var FilePath = Path.Combine(FolderPath, FileName);
                if (!AlwadaqContext.Set<NWC_Subscriber_File>().Any())
                {
                    var JsonData = await File.ReadAllTextAsync(FilePath);
                    var DataObjects = JsonSerializer.Deserialize<List<NWC_Subscriber_File_JSON>>(JsonData);
                    var MappedObjects = Subscribers_DataTypesEditor(DataObjects);
                    foreach (var obj in MappedObjects)
                    {
                        AlwadaqContext.Set<NWC_Subscriber_File>().Add(obj);
                        await AlwadaqContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataInitialization>();
                logger.LogError(ex.Message);
            }
        }
        private static List<NWC_Subscriber_File> Subscribers_DataTypesEditor(List<NWC_Subscriber_File_JSON> Subscribers_JSONs)
        {
            List<NWC_Subscriber_File> _Subscribers_Values = new List<NWC_Subscriber_File>();
            foreach (var item in Subscribers_JSONs)
            {
                NWC_Subscriber_File slice = new NWC_Subscriber_File()
                {
                    NWC_Subscriber_File_Id = item.NWC_Subscriber_File_Id.ToString(),
                    NWC_Subscriber_File_Name = item.NWC_Subscriber_File_Name,
                    NWC_Subscriber_File_City = item.NWC_Subscriber_File_City,
                    NWC_Subscriber_File_Area = item.NWC_Subscriber_File_Area,
                    NWC_Subscriber_File_Mobile = item.NWC_Subscriber_File_Mobile,
                    NWC_Subscriber_File_Reasons = item.NWC_Subscriber_File_Reasons
                };
                _Subscribers_Values.Add(slice);
            }
            return _Subscribers_Values;
        }

        private async static Task NWC_Rreal_Estate_Types_Data_Initialize_Async(GheyomAlwadaqContext AlwadaqContext, ILoggerFactory loggerFactory)
        {
            try
            {
                var FileName = "NWC_Rreal_Estate_Types.json";
                var FilePath = Path.Combine(FolderPath, FileName);
                if (!AlwadaqContext.Set<NWC_Rreal_Estate_Types>().Any())
                {
                    var JsonData = await File.ReadAllTextAsync(FilePath);
                    var DataObjects = JsonSerializer.Deserialize<List<NWC_Rreal_Estate_Types_JSON>>(JsonData);
                    var MappedObjects = Rreal_Estate_Types_DataTypesEditor(DataObjects);
                    foreach (var obj in MappedObjects)
                    {
                        AlwadaqContext.Set<NWC_Rreal_Estate_Types>().Add(obj);
                        await AlwadaqContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataInitialization>();
                logger.LogError(ex.Message);
            }
        }
        private static List<NWC_Rreal_Estate_Types> Rreal_Estate_Types_DataTypesEditor(List<NWC_Rreal_Estate_Types_JSON> Rreal_Estate_Types_JSON)
        {
            List<NWC_Rreal_Estate_Types> _Rreal_Estate_Types_Values = new List<NWC_Rreal_Estate_Types>();
            foreach (var item in Rreal_Estate_Types_JSON)
            {
                NWC_Rreal_Estate_Types slice = new NWC_Rreal_Estate_Types()
                {
                    NWC_Rreal_Estate_Types_Code = (char.Parse(item.NWC_Rreal_Estate_Types_Code.ToString())),
                    NWC_Rreal_Estate_Types_Name = item.NWC_Rreal_Estate_Types_Name,
                    NWC_Rreal_Estate_Types_Reasons = item.NWC_Rreal_Estate_Types_Reasons
                };
                _Rreal_Estate_Types_Values.Add(slice);
            }
            return _Rreal_Estate_Types_Values;
        }
        private async static Task NWC_Subscription_File_Data_Initialize_Async(GheyomAlwadaqContext AlwadaqContext, ILoggerFactory loggerFactory)
        {
            try
            {
                var FileName = "NWC_Subscribtion_Data.json";
                var FilePath = Path.Combine(FolderPath, FileName);
                if (!AlwadaqContext.Set<NWC_Subscription_File>().Any())
                {
                    var JsonData = await File.ReadAllTextAsync(FilePath);
                    var DataObjects = JsonSerializer.Deserialize<List<NWC_Subscription_File_JSON>>(JsonData);
                    var MappedObjects = Subscription_File_DataTypesEditor(DataObjects);
                    foreach (var obj in MappedObjects)
                    {
                        AlwadaqContext.Set<NWC_Subscription_File>().Add(obj);
                        await AlwadaqContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataInitialization>();
                logger.LogError(ex.Message);
            }
        }
        private static List<NWC_Subscription_File> Subscription_File_DataTypesEditor(List<NWC_Subscription_File_JSON> Subscribtion_JSONs)
        {
            List<NWC_Subscription_File> _NWC_Subscription_Files_Values = new List<NWC_Subscription_File>();
            foreach (var item in Subscribtion_JSONs)
            {
                NWC_Subscription_File slice = new NWC_Subscription_File()
                {
                    NWC_Subscription_File_No = item.NWC_Subscription_File_No,
                    NWC_Subscription_File_Subscriber_Code = item.NWC_Subscription_File_Subscriber_Code.ToString(),
                    NWC_Subscription_File_Rreal_Estate_Types_Code = char.Parse(item.NWC_Subscription_File_Rreal_Estate_Types_Code.ToString()),
                    NWC_Subscription_File_Unit_No = item.NWC_Subscription_File_Unit_No,
                    NWC_Subscription_File_Is_There_Sanitation = item.NWC_Subscription_File_Is_There_Sanitation,
                    NWC_Subscription_File_Last_Reading_Meter = item.NWC_Subscription_File_Last_Reading_Meter,
                    NWC_Subscription_File_Reasons = item.NWC_Subscription_File_Reasons
                };
                _NWC_Subscription_Files_Values.Add(slice);
            }
            return _NWC_Subscription_Files_Values;
        }
        private async static Task NWC_Invoices_Data_Initialize_Async(GheyomAlwadaqContext AlwadaqContext, ILoggerFactory loggerFactory)
        {
            try
            {
                var FileName = "NWC_Invoices.json";
                var FilePath = Path.Combine(FolderPath, FileName);
                if (!AlwadaqContext.Set<NWC_Invoices>().Any())
                {
                    var JsonData = await File.ReadAllTextAsync(FilePath);
                    var DataObjects = JsonSerializer.Deserialize<List<NWC_Invoices_JSON>>(JsonData);
                    var MappedObjects = Invoices_File_DataTypesEditor(DataObjects);
                    foreach (var obj in MappedObjects)
                    {
                        AlwadaqContext.Set<NWC_Invoices>().Add(obj);
                        await AlwadaqContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataInitialization>();
                logger.LogError(ex.Message);
            }
        }
        private static List<NWC_Invoices> Invoices_File_DataTypesEditor(List<NWC_Invoices_JSON> Invoices_JSONs)
        {
            List<NWC_Invoices> _NWC_Invoices = new List<NWC_Invoices>();
            foreach (var item in Invoices_JSONs)
            {
                NWC_Invoices slice = new NWC_Invoices()
                {
                    NWC_Invoices_No = item.NWC_Invoices_No,
                    NWC_Invoices_Year = item.NWC_Invoices_Year,
                    NWC_Invoices_Rreal_Estate_Types = char.Parse(item.NWC_Invoices_Rreal_Estate_Types),
                    NWC_Invoices_Subscription_No = item.NWC_Invoices_Subscription_No,
                    NWC_Invoices_Subscriber_No = item.NWC_Invoices_Subscriber_No,
                    NWC_Invoices_Date = DateTime.ParseExact(item.NWC_Invoices_Date,"yyyy/MM/dd" , CultureInfo.InvariantCulture).Date,
                    NWC_Invoices_From = DateTime.ParseExact(item.NWC_Invoices_From, "yyyy/MM/dd", CultureInfo.InvariantCulture),
                    NWC_Invoices_To = DateTime.ParseExact(item.NWC_Invoices_To, "yyyy/MM/dd", CultureInfo.InvariantCulture).Date,
                    NWC_Invoices_Previous_Consumption_Amount = int.Parse(item.NWC_Invoices_Previous_Consumption_Amount.Replace(",", "")),
                    NWC_Invoices_Current_Consumption_Amount = int.Parse(item.NWC_Invoices_Current_Consumption_Amount.Replace(",", "")),
                    NWC_Invoices_Amount_Consumption = int.Parse(item.NWC_Invoices_Amount_Consumption.Replace(",", "")),
                    NWC_Invoices_Service_Fee = decimal.Parse(item.NWC_Invoices_Service_Fee.Replace(",", "")),
                    NWC_Invoices_Tax_Rate = decimal.Parse(item.NWC_Invoices_Tax_Rate.Replace("%", "")),
                    NWC_Invoices_Is_There_Sanitation = item.NWC_Invoices_Is_There_Sanitation,
                    NWC_Invoices_Consumption_Value = decimal.Parse(item.NWC_Invoices_Consumption_Value),
                    NWC_Invoices_Wastewater_Consumption_Value = decimal.Parse(item.NWC_Invoices_Wastewater_Consumption_Value),
                    NWC_Invoices_Total_Invoice = decimal.Parse(item.NWC_Invoices_Total_Invoice),
                    NWC_Invoices_Tax_Value = decimal.Parse(item.NWC_Invoices_Tax_Value),
                    NWC_Invoices_Total_Bill = decimal.Parse(item.NWC_Invoices_Total_Bill)
                };
                _NWC_Invoices.Add(slice);
            }
            return _NWC_Invoices;
        }
    }
}
