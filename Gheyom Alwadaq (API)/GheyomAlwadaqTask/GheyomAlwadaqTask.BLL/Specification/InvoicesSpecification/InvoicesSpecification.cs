using Azure;
using GheyomAlwadaqTask.BLL.Specification.SubscriberSpecification;
using GheyomAlwadaqTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Specification.InvoicesSpecification
{
    public class InvoicesSpecification : Specification<NWC_Invoices>
    {
        public InvoicesSpecification(InvoicesParams InvoicesParams)
        {
            ApplyPagination(InvoicesParams.PageSize * (InvoicesParams.PageIndex - 1), InvoicesParams.PageSize);
        }
    }
}
