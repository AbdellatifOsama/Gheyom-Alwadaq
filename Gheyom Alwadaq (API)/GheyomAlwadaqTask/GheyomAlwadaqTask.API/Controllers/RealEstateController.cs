using GheyomAlwadaqTask.API.DTOs;
using GheyomAlwadaqTask.BLL.Interfaces;
using GheyomAlwadaqTask.BLL.Repositories;
using GheyomAlwadaqTask.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GheyomAlwadaqTask.API.Controllers
{
    public class RealEstateController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;

        public RealEstateController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var RealEstates = await unitOfWork.Rreal_Estate_Repository.GetAll();
            return Ok(RealEstates);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRealEstate(string id)
        {
            var RealEstate = await unitOfWork.Rreal_Estate_Repository.FindStateByNumber(id[0]);
            if (RealEstate is not null)
                return Ok(new
                {
                    Message = "success",
                    RealEstate = RealEstate
                });
            return Ok(new ErrorResponseDto(404, "RealEstate"));
        }
        [HttpPut]
        public async Task<IActionResult> Update(NWC_Rreal_Estate_Types estate, char id)
        {
            var RealEstate = await unitOfWork.Rreal_Estate_Repository.FindStateByNumber(id);
            if (RealEstate != null && id != null && estate != null)
            {
                RealEstate.NWC_Rreal_Estate_Types_Name = estate.NWC_Rreal_Estate_Types_Name;
                RealEstate.NWC_Rreal_Estate_Types_Reasons = estate.NWC_Rreal_Estate_Types_Reasons;
                await unitOfWork.Rreal_Estate_Repository.Update(RealEstate);
                return Ok(new
                {
                    status = 200,
                    message = "success"
                });
            }
            return Ok(new ErrorResponseDto(404, "RealEstate"));
        }
    }
}
