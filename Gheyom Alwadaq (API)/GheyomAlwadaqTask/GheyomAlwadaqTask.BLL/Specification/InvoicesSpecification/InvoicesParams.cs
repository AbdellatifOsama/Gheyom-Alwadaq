using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Specification.InvoicesSpecification
{
    public class InvoicesParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 20;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
    }
}
