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
    public class SubscriberRepository : GenericRepository<NWC_Subscriber_File>, ISubscriberRepository
    {
        public SubscriberRepository(GheyomAlwadaqContext context):base(context)
        {
            
        }
    }
}
