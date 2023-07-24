using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public ISubscriberRepository SubscriberRepository { get; set; }
        public ISubscribtionRepository SubscribtionRepository { get; set; }
        public IRreal_Estate_Repository Rreal_Estate_Repository { get; set; }
        public IInvoicesRepository InvoicesRepository { get; set; }
    }
}
