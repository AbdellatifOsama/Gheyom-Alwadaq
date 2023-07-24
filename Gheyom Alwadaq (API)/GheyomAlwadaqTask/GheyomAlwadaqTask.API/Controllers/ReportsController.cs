using AutoMapper;
using GheyomAlwadaqTask.API.DTOs;
using GheyomAlwadaqTask.BLL.Interfaces;
using GheyomAlwadaqTask.BLL.Specification.InvoicesSpecification;
using GheyomAlwadaqTask.BLL.Specification.SubscriberSpecification;
using GheyomAlwadaqTask.BLL.Specification.SubscribtionSpecification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GheyomAlwadaqTask.API.Controllers
{
    public class ReportsController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReportsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet("Subscribtions")]
        public async Task<IActionResult> GetSubscribtionsReport([FromQuery] SubscribtionParams subscribtionsParams)
        {
            var spec = new SubscribtionSpecification(subscribtionsParams);
            var Subscribtions = await unitOfWork.SubscribtionRepository.GetAllWithSpecAsync(spec);
            var SubscribtionsCount = (await unitOfWork.SubscribtionRepository.GetAllWithSpecAsync(new GetSubscribtionsTotalCounts())).Count;
            var FlatSubscribtions = mapper.Map<List<FlatSubscribtionDTO>>(Subscribtions);
            var SubscribtionsReportPagination = new PaginationResponseDto<FlatSubscribtionDTO>(subscribtionsParams.PageIndex, subscribtionsParams.PageSize, SubscribtionsCount, FlatSubscribtions);
            return Ok(SubscribtionsReportPagination);
        }
        [HttpGet("Subscribers")]
        public async Task<IActionResult> GetSubscribersReport([FromQuery] SubscriberParams subscriberParams)
        {
            var spec = new SubscriberSpecification(subscriberParams);
            var Subscribers = await unitOfWork.SubscriberRepository.GetAllWithSpecAsync(spec);
            var SubscribersCount = (await unitOfWork.SubscribtionRepository.GetAllWithSpecAsync(new GetSubscribtionsTotalCounts())).Count;
            var SubscribersReport = mapper.Map<List<SubscriberReport>>(Subscribers);
            var SubscribersReportPagination = new PaginationResponseDto<SubscriberReport>(subscriberParams.PageIndex, subscriberParams.PageSize, SubscribersCount, SubscribersReport);
            return Ok(SubscribersReportPagination);
        }
        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoicesReports([FromQuery] InvoicesParams invoicesParams)
        {
            var spec = new InvoicesSpecification(invoicesParams);
            var Invoices = await unitOfWork.InvoicesRepository.GetAllWithSpecAsync(spec);
            var InvoicesCount = (await unitOfWork.InvoicesRepository.GetAllWithSpecAsync(new GetIvoicesTotalCounts())).Count;
            var InvoicesReport = mapper.Map<List<InvoicesReportDto>>(Invoices);
            var SubscribersReportPagination = new PaginationResponseDto<InvoicesReportDto>(invoicesParams.PageIndex, invoicesParams.PageSize, InvoicesCount, InvoicesReport);
            return Ok(SubscribersReportPagination);
        }
    }
}
