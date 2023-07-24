using AutoMapper;
using GheyomAlwadaqTask.API.DTOs;
using GheyomAlwadaqTask.BLL.Interfaces;
using GheyomAlwadaqTask.BLL.Repositories;
using GheyomAlwadaqTask.DAL.Entities;

namespace GheyomAlwadaqTask.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(IUnitOfWork unitOfWork)
        {
            CreateMap<NWC_Subscriber_File, SubscriberDTO>()
                .ForMember(P => P.NWC_Subscriber_File_Reasons, o => o.MapFrom(s => s.NWC_Subscriber_File_Reasons ?? ""))
                .ReverseMap();
            CreateMap<NWC_Subscription_File, SubscribtionDTO>()
                .ForMember(P => P.NWC_Subscription_File_No, o => o.MapFrom(s => s.NWC_Subscription_File_No.Trim()))
                .ForMember(P => P.NWC_Subscription_File_Reasons, o => o.MapFrom(s => s.NWC_Subscription_File_Reasons ?? "")).ReverseMap();
            CreateMap<NWC_Subscription_File, FlatSubscribtionDTO>()
                 .ForMember(P => P.NWC_Subscriber_File_Id, o => o.MapFrom(s => s.NWC_Subscription_File_Subscriber_Code.Trim()))
                 .ForMember(P => P.NWC_Subscription_File_No, o => o.MapFrom(s => s.NWC_Subscription_File_No.Trim()))
                 .ForMember(P => P.NWC_Rreal_Estate_Types_Code, o => o.MapFrom(s => s.NWC_Subscription_File_Rreal_Estate_Types_Code))
                 .ForMember(P => P.NWC_Rreal_Estate_Types_Name, o => o.MapFrom(s => unitOfWork.Rreal_Estate_Repository.FindStateByNumber(s.NWC_Subscription_File_Rreal_Estate_Types_Code).Result.NWC_Rreal_Estate_Types_Name))
                 .ForMember(P => P.NWC_Subscriber_File_Name, o => o.MapFrom(s => unitOfWork.SubscriberRepository.GetById((s.NWC_Subscription_File_Subscriber_Code)).Result.NWC_Subscriber_File_Name))
                 .ForMember(P => P.nwC_Subscriber_File_Mobile, o => o.MapFrom(s => unitOfWork.SubscriberRepository.GetById((s.NWC_Subscription_File_Subscriber_Code)).Result.NWC_Subscriber_File_Mobile))
                 .ReverseMap();
            CreateMap<NWC_Subscriber_File, SubscriberReport>()
                .ForMember(P => P.NWC_Subscriber_File_Reasons, o => o.MapFrom(s => s.NWC_Subscriber_File_Reasons ?? ""))
                .ForMember(P => P.nwC_Subscriber_File_Subscribtions_No, o => o.MapFrom(s => unitOfWork.SubscribtionRepository.GetAll().Result.Where(P => P.NWC_Subscription_File_Subscriber_Code == s.NWC_Subscriber_File_Id).Count()))
                .ReverseMap();
            CreateMap<NWC_Invoices, InvoicesReportDto>()
                .ForMember(P => P.NWC_Invoices_Subscriber_Name, o => o.MapFrom(s => unitOfWork.SubscriberRepository.GetById((s.NWC_Invoices_Subscriber_No)).Result.NWC_Subscriber_File_Name))
                .ForMember(P => P.NWC_Invoices_Date, o => o.MapFrom(s => s.NWC_Invoices_Date.ToString("yyyy/MM/dd")))
                .ForMember(P => P.NWC_Invoices_No, o => o.MapFrom(s => s.NWC_Invoices_No.Trim()))
                .ForMember(P => P.NWC_Invoices_Subscription_No, o => o.MapFrom(s => s.NWC_Invoices_Subscription_No.Trim()))
                .ReverseMap();
            CreateMap<NWC_Invoices, InvoiceInqueryDto>()
                .ForMember(P => P.NWC_Invoices_Subscriber_Name, o => o.MapFrom(s => unitOfWork.SubscriberRepository.GetById((s.NWC_Invoices_Subscriber_No)).Result.NWC_Subscriber_File_Name))
                .ForMember(P => P.NWC_Invoices_Date, o => o.MapFrom(s => s.NWC_Invoices_Date.ToString("yyyy/MM/dd")))
                .ForMember(P => P.NWC_Invoices_From, o => o.MapFrom(s => s.NWC_Invoices_Date.ToString("yyyy/MM/dd")))
                .ForMember(P => P.NWC_Invoices_Subscription_File_Unit_No, o => o.MapFrom(s => unitOfWork.SubscribtionRepository.GetById((s.NWC_Invoices_Subscription_No)).Result.NWC_Subscription_File_Unit_No))
                .ForMember(P => P.NWC_Invoices_To, o => o.MapFrom(s => s.NWC_Invoices_Date.ToString("yyyy/MM/dd")))
                .ForMember(P => P.NWC_Invoices_No, o => o.MapFrom(s => s.NWC_Invoices_No.Trim()))
                .ForMember(P => P.NWC_Invoices_Subscription_No, o => o.MapFrom(s => s.NWC_Invoices_Subscription_No.Trim()))
                .ForMember(P => P.NWC_Invoices_Total_Reasons, o => o.MapFrom(s => s.NWC_Invoices_Total_Reasons ?? ""))
                .ReverseMap();
        }
    }
}
