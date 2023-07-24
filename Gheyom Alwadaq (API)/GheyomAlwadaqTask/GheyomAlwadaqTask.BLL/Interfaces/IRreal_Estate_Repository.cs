using GheyomAlwadaqTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Interfaces
{
    public interface IRreal_Estate_Repository:IGenericRepository<NWC_Rreal_Estate_Types>
    {
        public Task<NWC_Rreal_Estate_Types> FindStateByNumber(char c);
    }
}
