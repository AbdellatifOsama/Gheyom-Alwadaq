using GheyomAlwadaqTask.BLL.Interfaces;
using GheyomAlwadaqTask.DAL.Data;
using GheyomAlwadaqTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Repositories
{
    public class InvoicesRepository : GenericRepository<NWC_Invoices>, IInvoicesRepository
    {
        public InvoicesRepository(GheyomAlwadaqContext context) : base(context)
        {
        }
    }
}
