using AutoMapper;
using GheyomAlwadaqTask.API.DTOs;
using GheyomAlwadaqTask.BLL.Interfaces;
using GheyomAlwadaqTask.BLL.Specification.SubscriberSpecification;
using GheyomAlwadaqTask.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GheyomAlwadaqTask.API.Controllers
{
    public class SubscriberController : BaseController
    {
        private readonly ISubscriberRepository subscriberRepository;
        private readonly IMapper mapper;

        public SubscriberController(ISubscriberRepository subscriberRepository, IMapper mapper)
        {
            this.subscriberRepository = subscriberRepository;
            this.mapper = mapper;
        }
        #region Get All Subscribers
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSubscribers([FromQuery] SubscriberParams subscriberParams)
        {
            var spec = new SubscriberSpecification(subscriberParams);
            var Subscribers = await subscriberRepository.GetAllWithSpecAsync(spec);
            var SubscribersCount = (await subscriberRepository.GetAllWithSpecAsync(new GetSubscribersTotalCounts())).Count;
            var MappedSubscribers = mapper.Map<List<SubscriberDTO>>(Subscribers);
            var SubscribersPagination = new PaginationResponseDto<SubscriberDTO>(subscriberParams.PageIndex, subscriberParams.PageSize, SubscribersCount, MappedSubscribers);
            return Ok(SubscribersPagination);
        }
        #endregion

        #region Get Latest Subscribers
        [HttpGet("GetLatest")]
        public async Task<IActionResult> GetLatestSubscribers()
        {
            var LatestSubscribers = await subscriberRepository.GetAll();
            return Ok(LatestSubscribers.ToArray()[(LatestSubscribers.Count - 20)..]);
        }
        #endregion

        #region Get Subscriber
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriber(string id)
        {
            var Subscriber = await subscriberRepository.GetById(id);
            if (Subscriber is not null)
            {
                var mappedSubscriber = mapper.Map<SubscriberDTO>(Subscriber);
                return Ok(new
                {
                    Message = "success",
                    User = mappedSubscriber
                });
            };
            return Ok(new ErrorResponseDto(404, "Subscriber"));
        }
        #endregion

        #region Add New Subscriber
        [HttpPost]
        public async Task<IActionResult> AddSubscriber(SubscriberDTO subscriberDto)
        {
            var CheckIfSubscriberIdFound = await subscriberRepository.GetById(subscriberDto.NWC_Subscriber_File_Id);
            if (CheckIfSubscriberIdFound is null)
            {
                var Subscriber = mapper.Map<SubscriberDTO, NWC_Subscriber_File>(subscriberDto);
                await subscriberRepository.Add(Subscriber);
                var AddedSubscriber = await subscriberRepository.GetById(Subscriber.NWC_Subscriber_File_Id);
                if (AddedSubscriber is not null)
                    return Ok(new ErrorResponseDto(200, "Subscriber"));
                else
                    return Ok(new ErrorResponseDto(400, "Subscriber"));
            }
            else
                return Ok(new ErrorResponseDto(302, "Subscriber"));
        }
        #endregion

        #region Update Subsriber
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateSubscriber(SubscriberDTO subscriberDto, string id)
        {
            var Subscriber = await subscriberRepository.GetById(subscriberDto.NWC_Subscriber_File_Id);
            if (Subscriber is not null && Subscriber?.NWC_Subscriber_File_Id == id && ModelState.IsValid)
            {
                Subscriber.NWC_Subscriber_File_Name = subscriberDto.NWC_Subscriber_File_Name;
                Subscriber.NWC_Subscriber_File_City = subscriberDto.NWC_Subscriber_File_City;
                Subscriber.NWC_Subscriber_File_Mobile = subscriberDto.NWC_Subscriber_File_Mobile;
                Subscriber.NWC_Subscriber_File_Reasons = subscriberDto.NWC_Subscriber_File_Reasons;
                await subscriberRepository.Update(Subscriber);
                return Ok(new ErrorResponseDto(200, "Subscriber"));
            }
            else
                return Ok(new ErrorResponseDto(500, "Subscriber"));
        }
        #endregion

        #region Delete Susbcriber
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSubscriber(SubscriberDTO subscriberDto, string id)
        {
            var Subscriber = await subscriberRepository.GetById(subscriberDto.NWC_Subscriber_File_Id);
            if (Subscriber is not null && Subscriber?.NWC_Subscriber_File_Id == id && ModelState.IsValid)
            {
                await subscriberRepository.Delete(Subscriber);
                return Ok(new ErrorResponseDto(200, "Subscriber"));
            }
            else
                return Ok(new ErrorResponseDto(500, "Subscriber"));
        }
        #endregion
    }
}
