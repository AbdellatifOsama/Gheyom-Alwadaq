using AutoMapper;
using GheyomAlwadaqTask.API.DTOs;
using GheyomAlwadaqTask.BLL.Interfaces;
using GheyomAlwadaqTask.BLL.Repositories;
using GheyomAlwadaqTask.BLL.Specification.SubscribtionSpecification;
using GheyomAlwadaqTask.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GheyomAlwadaqTask.API.Controllers
{
    public class SubscribtionController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SubscribtionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSubscribtions([FromQuery] SubscribtionParams subscriberParams)
        {
            var spec = new SubscribtionSpecification(subscriberParams);
            var Subscribtions = await unitOfWork.SubscribtionRepository.GetAllWithSpecAsync(spec);
            var MappedSubscribtion = mapper.Map<List<SubscribtionDTO>>(Subscribtions);
            var SubscribtionsCount = (await unitOfWork.SubscribtionRepository.GetAllWithSpecAsync(new GetSubscribtionsTotalCounts())).Count;
            var SubscribersPagination = new PaginationResponseDto<SubscribtionDTO>(subscriberParams.PageIndex, subscriberParams.PageSize, SubscribtionsCount, MappedSubscribtion);
            return Ok(SubscribersPagination);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscribtionById(string id)
        {
            var Subscribtion = await unitOfWork.SubscribtionRepository.GetById(id.Trim());
            if (Subscribtion is not null)
            {
                var flat = mapper.Map<FlatSubscribtionDTO>(Subscribtion);
                return Ok(flat);
            };
            return Ok(new ErrorResponseDto(404, "Subscriber"));
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateSubscribtion(SubscribtionDTO SubscribtionDTO)
        {
            var Subscribtion = await unitOfWork.SubscribtionRepository.GetById(SubscribtionDTO.NWC_Subscription_File_No);
            if (Subscribtion is not null && ModelState.IsValid)
            {
                Subscribtion.NWC_Subscription_File_Subscriber_Code = SubscribtionDTO.NWC_Subscription_File_Subscriber_Code;
                Subscribtion.NWC_Subscription_File_Rreal_Estate_Types_Code = SubscribtionDTO.NWC_Subscription_File_Rreal_Estate_Types_Code;
                Subscribtion.NWC_Subscription_File_Unit_No = SubscribtionDTO.NWC_Subscription_File_Unit_No;
                Subscribtion.NWC_Subscription_File_Is_There_Sanitation = SubscribtionDTO.NWC_Subscription_File_Is_There_Sanitation;
                Subscribtion.NWC_Subscription_File_Last_Reading_Meter = SubscribtionDTO.NWC_Subscription_File_Last_Reading_Meter;
                Subscribtion.NWC_Subscription_File_Reasons = SubscribtionDTO.NWC_Subscription_File_Reasons;
                await unitOfWork.SubscribtionRepository.Update(Subscribtion);
                return Ok(new ErrorResponseDto(200, "Subscriber"));
            }
            else
                return Ok(new ErrorResponseDto(500, "Subscriber"));
        }
    }
}
