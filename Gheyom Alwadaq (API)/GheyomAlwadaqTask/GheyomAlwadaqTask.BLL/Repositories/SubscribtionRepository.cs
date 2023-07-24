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
    public class SubscribtionRepository : GenericRepository<NWC_Subscription_File>, ISubscribtionRepository
    {
        public SubscribtionRepository(GheyomAlwadaqContext context) : base(context)
        {
        }
    }
}
