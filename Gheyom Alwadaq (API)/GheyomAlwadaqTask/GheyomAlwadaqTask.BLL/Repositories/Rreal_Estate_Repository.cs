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
    public class Rreal_Estate_Repository : GenericRepository<NWC_Rreal_Estate_Types>, IRreal_Estate_Repository
    {
        public Rreal_Estate_Repository(GheyomAlwadaqContext context) : base(context)
        {
            Context = context;
        }

        public GheyomAlwadaqContext Context { get; }

        public async  Task<NWC_Rreal_Estate_Types> FindStateByNumber(char c) 
        { 
           var RealState =  await Context.Set<NWC_Rreal_Estate_Types>().FindAsync(c);
            return RealState;
        }
    }
}
