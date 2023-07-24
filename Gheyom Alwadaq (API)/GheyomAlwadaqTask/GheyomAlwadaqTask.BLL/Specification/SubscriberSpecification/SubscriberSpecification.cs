using Azure;
using GheyomAlwadaqTask.BLL.Specification.SubscriberSpecification;
using GheyomAlwadaqTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Specification.SubscriberSpecification
{
    public class SubscriberSpecification : Specification<NWC_Subscriber_File>
    {
        public SubscriberSpecification(SubscriberParams subscriberParams)
        {
            if (!string.IsNullOrEmpty(subscriberParams.Sort))
            {
                switch (subscriberParams.Sort)
                {
                    case "IdAsc":
                        OrderBy(P => P.NWC_Subscriber_File_Id);
                        break;
                    case "IdDesc":
                        OrderByDesc(P => P.NWC_Subscriber_File_Id);
                        break;
                    case "NameAsc":
                        OrderBy(S => S.NWC_Subscriber_File_Name);
                        break;
                    case "NameDesc":
                        OrderByDesc(P => P.NWC_Subscriber_File_Name);
                        break;
                    default:
                        break;
                }
            }
            ApplyPagination(subscriberParams.PageSize * (subscriberParams.PageIndex - 1), subscriberParams.PageSize);
        }
    }
}
