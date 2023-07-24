using Azure;
using GheyomAlwadaqTask.BLL.Specification.SubscriberSpecification;
using GheyomAlwadaqTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Specification.SubscribtionSpecification
{
    public class SubscribtionSpecification:Specification<NWC_Subscription_File>
    {
        public SubscribtionSpecification(SubscribtionParams subscribtionParams)
        {
            //if (!string.IsNullOrEmpty(subscriberParams.Sort))
            //{
            //    switch (subscriberParams.Sort)
            //    {
            //        case "IdAsc":
            //            OrderBy(P => P.NWC_Subscriber_File_Id);
            //            break;
            //        case "IdDesc":
            //            OrderByDesc(P => P.NWC_Subscriber_File_Id);
            //            break;
            //        case "NameAsc":
            //            OrderBy(S => S.NWC_Subscriber_File_Name);
            //            break;
            //        case "NameDesc":
            //            OrderByDesc(P => P.NWC_Subscriber_File_Name);
            //            break;
            //        default:
            //            break;
            //    }
            //}
            ApplyPagination(subscribtionParams.PageSize * (subscribtionParams.PageIndex - 1), subscribtionParams.PageSize);
        }
    }
}
