using GheyomAlwadaqTask.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheyomAlwadaqTask.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //public ISubscriberRepository SubscriberRepository;

        //public ISubscribtionRepository SubscribtionRepository;

        //public IRreal_Estate_Repository Rreal_Estate_Repository;
        public ISubscriberRepository SubscriberRepository { get; set; }
        public ISubscribtionRepository SubscribtionRepository { get; set; }
        public IRreal_Estate_Repository Rreal_Estate_Repository { get; set; }
        public IInvoicesRepository InvoicesRepository { get; set; }

        public UnitOfWork(ISubscriberRepository SubscriberRepository, ISubscribtionRepository SubscribtionRepository, IRreal_Estate_Repository Rreal_Estate_Repository, IInvoicesRepository InvoicesRepository)
        {
            this.SubscribtionRepository = SubscribtionRepository;
            this.SubscriberRepository = SubscriberRepository;
            this.Rreal_Estate_Repository = Rreal_Estate_Repository;
            this.InvoicesRepository = InvoicesRepository;
        }

    }
}
