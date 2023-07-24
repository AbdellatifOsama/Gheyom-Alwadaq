using AutoMapper;
using GheyomAlwadaqTask.API.DTOs;
using GheyomAlwadaqTask.BLL.Interfaces;
using GheyomAlwadaqTask.BLL.Repositories;
using GheyomAlwadaqTask.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace GheyomAlwadaqTask.API.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public InvoiceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceDetails(string id)
        {
            var Invoice = await unitOfWork.InvoicesRepository.GetById(id);
            if (Invoice is not null)
            {
                var mapped = mapper.Map<InvoiceInqueryDto>(Invoice);
                return Ok(new
                {
                    Message = "success",
                    Invoice = mapped
                });
            }
            return Ok(new ErrorResponseDto(404, "Invoice"));
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddInvoiceRequest(InvoiceInqueryDto invoiceInqueryDto)
        {
            if (invoiceInqueryDto is not null && ModelState.IsValid)
            {
                var mapped = mapper.Map<NWC_Invoices>(invoiceInqueryDto);
                await unitOfWork.InvoicesRepository.Add(mapped);
                return Ok(new
                {
                    Message = "success",
                    Invoice = mapped
                });
            }
            return Ok(new ErrorResponseDto(999,"Invoice"));
        }
    }
}
